using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;
using UnityEngine.Rendering.Universal;
using UnityEditor.VersionControl;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody prb;
    private Vector2 moveDirection;
    public NewControls movePlayer;
    private InputAction movement;
    private InputAction dash;
    private InputAction pow;

    private Vector3 starting, dashDir, respawn;

    public float moveSpeed;
    public static float health = 100;

    private float maxHealth;

    //Mo Edits
    //[SerializeField]
    public float dashSpeed, dashTime, shootDelay;

    [SerializeField]
    private TMP_Text healthText, ammoText;

    Vector3 lookDirection;

    //Gun Variables
    [SerializeField]
    private GameObject bullet, rayObj;
    private bool shooting, dashing;
    public int shots;
    private int OriginalShots;


    private void Awake()
    {
        prb = GetComponent<Rigidbody>();
        movePlayer = new NewControls();
        starting = transform.position;
        shooting = false;
        OriginalShots = shots;
        maxHealth = health;
        dashing = false;
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

        //set up the attack button
        pow = movePlayer.Player.Attack;
        pow.Enable();
        pow.performed += DamageTime;
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
        if (health <= 0)
        {
            transform.position = starting;
            health = 100;
        }
        if(!dashing)
        {
            moveDirection = movement.ReadValue<Vector2>();
            transform.position += new Vector3(moveDirection.x, 0, moveDirection.y) * Time.deltaTime * moveSpeed;
            dashDir = new Vector3(moveDirection.x, 1.5f, moveDirection.y);


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
        }
        

        RaycastHit objectHit;
        Vector3 fwd = rayObj.transform.TransformDirection(moveDirection);
        Debug.DrawRay(rayObj.transform.position, fwd * 1, Color.green);
        if (Physics.Raycast(rayObj.transform.position, fwd, out objectHit, 10))
        {

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

    public void DodgeRoll(InputAction.CallbackContext context)
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
    }

    private void SetText()
    {
        healthText.SetText("Player Health:" + Convert.ToInt32(health));
        ammoText.SetText("Ammo:" + shots.ToString());
    }

    private void DamageTime(InputAction.CallbackContext context )
    {
        Gunshots();
    }

    private void Gunshots()
    {
        if(!shooting)
        {
            shots--;
            if(shots > 0)
            {
                StartCoroutine(Shooting());
            }
            if(shots <=0) 
                shots = 0;
        }
    }
    private IEnumerator Shooting()
    {
        shooting = true;
        Instantiate(bullet, transform.position, transform.rotation);
        yield return new WaitForSeconds(shootDelay);
        shooting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ammo")
        {
            shots = OriginalShots;
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
}
