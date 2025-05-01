using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;
using UnityEngine.Rendering.Universal;
//using UnityEditor.VersionControl;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody prb;
    private Vector2 moveDirection;
    public NewControls movePlayer;
    private InputAction movement;
    private InputAction dash;
    private InputAction pow;
    private InputAction swap;
    private Animator anim;
    public GameObject playerRig;

    private Vector3 starting, dashDir, respawn;

    public float moveSpeed;
    public static float health = 100;
    private int coinflip;
    public static bool bulletChance;
    public static bool regularShooting;

    public static float maxHealth;

    //Mo Edits
    //[SerializeField]
    public float dashSpeed, dashTime, shootDelay, swingDelay;
    //public GameObject PlayerCanvasThing;

    [SerializeField]
    private TMP_Text healthText, ammoText;

    Vector3 lookDirection;

    //Mo Edits - public og
    //Gun Variables
    [SerializeField]
    private GameObject bullet, rayObj, MeleeBox;
    private bool shooting, swinging;
    public bool hasGun, knifeMode;
    public int shots;
    public int OriginalShots;

    //Sprint Variables
    private bool isSprinting = false;
    [SerializeField]
    private UnityEngine.UI.Image StaminaBar;
/*    [SerializeField]
    private TMP_Text boostText;*/
    //[SerializeField]
    public float stamina, maxStamina, boostCost, normSpeed;
    private Coroutine recharge;

    [SerializeField]
    private GameObject Gun, Melee;


    private void Awake()
    {   
        //prb = GetComponent<Rigidbody>();
        movePlayer = new NewControls();
        starting = transform.position;
        shooting = false;
        OriginalShots = shots;
        maxHealth = health;
        normSpeed = moveSpeed;

        bulletChance = false;
        regularShooting = true;



        anim = playerRig.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        //set up movement
        movement = movePlayer.Player.Movement;
        movement.Enable();

        //set up Shooting

        dash = movePlayer.Player.Dash;
        dash.Enable();
        dash.performed += DodgeRoll;
        dash.canceled += DodgeRoll;

        //set up the attack button
        pow = movePlayer.Player.Attack;
        pow.Enable();
        pow.performed += DamageTime;

        //set up the attack button
        swap = movePlayer.Player.Swap;
        swap.Enable();
        swap.performed += ChangeWeapon;
    }

    private void OnDisable()
    {
        movement.Disable();
        dash.Disable();
        pow.Disable();
    }


    private void Update()
    {
        SetText();

        moveDirection = movement.ReadValue<Vector2>();
        Sprinting();

        if (health <= 0)
        {
            /*transform.position = starting;
            health = 100;
            PlayerTP.flag = true;
            PlayerTP.flag2 = true;
            PlayerTP.flag3 = true;*/

            SceneManager.LoadScene("Game_Over_Scene");
            //this.gameObject.SetActive(true);
        }

        
        //if(!dashing)
        //{



        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))

            {
                lookDirection = hit.point;
                lookDirection.y = 0;

                transform.LookAt(new Vector3(lookDirection.x, transform.position.y, lookDirection.z));
                /*lookDirection = hit.point - transform.position;

                transform.LookAt(hit.point);*/
            }
        //}
        

        RaycastHit objectHit;
        Vector3 fwd = rayObj.transform.TransformDirection(moveDirection);
        Debug.DrawRay(rayObj.transform.position, fwd * 1, Color.green);
        if (Physics.Raycast(rayObj.transform.position, fwd, out objectHit, 10))
        {

        }

        if(knifeMode)
        {
            Melee.SetActive(true);
            Gun.SetActive(false);
        }
        else
        {
            Melee.SetActive(false);
            Gun.SetActive(true);
        }
    }

    /*private void DodgeRoll(InputAction.CallbackContext context)
    {
        Debug.Log("Dash");
        float temp = moveSpeed;
        StartCoroutine(Dash());
        moveSpeed = temp;
    }

    private IEnumerator Dash()
    {
        float startTime = Time.time;
        float temp = moveSpeed;

        while(Time.time < startTime + dashTime) 
        {
            moveSpeed = dashSpeed;

            yield return null;
            moveSpeed = temp;
        }
    }*/

    /*public void DodgeRoll(InputAction.CallbackContext context)
    {
        Debug.Log("Dash");
        if (!dashing)
        {
            prb.AddForce(new Vector3(dashDir.x , 0, dashDir.z) * dashSpeed*10);
        }
        StartCoroutine(Dash());
    }

    private IEnumerator Dash()
    {
        dashing = true;
        yield return new WaitForSeconds(1f);
        dashing = false;
    }*/

    private void SetText()
    {
        healthText.SetText("Player Health:" + Convert.ToInt32(health));
        ammoText.SetText("Ammo:" + shots.ToString());
    }
    #region Attack
    private void DamageTime(InputAction.CallbackContext context )
    {
        if(hasGun && !knifeMode)
        {
            //Ranged Attack
            Gunshots();
            print("I'm shooting");
            anim.SetTrigger("isShooting");
        }
        else
        {
            //Melee attack
            HomeRun();
            print("I'm whacking");
            anim.SetTrigger("isWhacking");
        }
    }

    private void Gunshots()
    {
        if(!shooting)
        {
            if (bulletChance) {
                coinflip = Random.Range(1, 10);
                if (coinflip % 2 == 0)
                {
                    StartCoroutine(Shooting());
                }
                else
                {
                    shots--;
                }
            }

            if (regularShooting)
            {
                shots--;
            }

            if (shots > 0)
            {
                StartCoroutine(Shooting());
            }
            if(shots <=0)
            {
                shots = 0;
                hasGun = false;
                knifeMode = true;
            }
        }
    }

    private IEnumerator Shooting()
    {
        shooting = true;
        Instantiate(bullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(.1f);
        shooting = false;
    }

    private void HomeRun()
    {
        if(!swinging)
        {
            StartCoroutine(MeleeSwing());
        }
    }

    private IEnumerator MeleeSwing()
    {
        swinging = true;
        MeleeBox.SetActive(true);
        yield return new WaitForSeconds(swingDelay);
        MeleeBox.SetActive(false);
        swinging = false;
    }

    private void ChangeWeapon(InputAction.CallbackContext context)
    {
        //swap weapons
        knifeMode = !knifeMode;

    }

    #endregion

    #region Sprinting

    private void DodgeRoll(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("startRunning");
            isSprinting = true;
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            Debug.Log("SlowYourRoll");
            isSprinting = false;
        }
    }
    public void Sprinting()
    {
        if(!BearTrap.holding)
        {
            if (isSprinting)
            {
                anim.SetBool("isSprinting", true);
                moveSpeed = dashSpeed;
                stamina -= boostCost * Time.deltaTime;
                if (stamina < 0)
                {
                    stamina = 0;
                    isSprinting = false;
                }
                StaminaBar.fillAmount = stamina / maxStamina;
                //boostText.text = "Boost: " + (int)stamina + "/" + (int)maxStamina;
                if (recharge != null) StopCoroutine(recharge);
                recharge = StartCoroutine(RechargeStamina());
            }
            else
            {
                moveSpeed = normSpeed;
                anim.SetBool("isSprinting", false);
            }
            transform.position += new Vector3(moveDirection.x, 0, moveDirection.y) * Time.deltaTime * moveSpeed;
        }  
    }

    public IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(1f);

        while (stamina < maxStamina)
        {
            stamina += boostCost / 10f;
            //if the stamina bar gets full set the stamina to max stamina
            if (stamina > maxStamina) stamina = maxStamina;
            //update the stamina bar
            StaminaBar.fillAmount = stamina / maxStamina;
            //boostText.text = "Boost: " + (int)stamina + "/" + (int)maxStamina;
            yield return new WaitForSeconds(.1f);
        }
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ammo")
        {
            shots = OriginalShots;
            hasGun = true;
            //knifeMode = false;
            Destroy(other.gameObject);
        }

        if (other.tag == "Death")
        {
            health = 0;
        }

        if (other.tag == "LowAttack")
        {
            health -= 10;
        }

        if (other.name == "WhispShot")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "MidAttack")
        {
            health -= 25;
        }

        if (other.tag == "HighAttack")
        {
            health -= 35;
        }

        if (other.tag == "LowHeal")
        {
            if(health < maxHealth)
            {
                health += 10;
                if(health > maxHealth)
                {
                    health = maxHealth;
                }
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "MidHeal")
        {
            if (health < maxHealth)
            {
                health += 20;
                if (health > maxHealth)
                {
                    health = maxHealth;
                }
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "HighHeal")
        {
            if (health < maxHealth)
            {
                health += 30;
                if (health > maxHealth)
                {
                    health = maxHealth;
                }
            }
            Destroy(other.gameObject);
        }

        if (other.tag == "Fall")
        {
            respawn = transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "FZ")
        {
            transform.position = respawn;
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("FasterDash");
        PlayerPrefs.DeleteKey("FasterKey");
        PlayerPrefs.DeleteKey("GlassTrap");
        PlayerPrefs.DeleteKey("MoreStamina");
        PlayerPrefs.DeleteKey("MoreAmmo");
        PlayerPrefs.DeleteKey("ZombieAmmo");
        PlayerPrefs.DeleteKey("Bullet");
        PlayerPrefs.DeleteKey("Instakill");
        PlayerPrefs.DeleteKey("Health1");
        PlayerPrefs.DeleteKey("Health2");
    }
}
