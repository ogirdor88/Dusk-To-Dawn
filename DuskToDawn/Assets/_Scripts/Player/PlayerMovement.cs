using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;
using UnityEngine.Rendering.Universal;
using UnityEditor.VersionControl;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDirection;
    public NewControls movePlayer;
    private InputAction movement;
    private InputAction dash;
    private InputAction pow;

    private Vector3 starting;

    public float moveSpeed;
    public static float health = 100;

    [SerializeField]
    private float dashSpeed, dashTime, shootDelay;

    [SerializeField]
    private TMP_Text healthText, ammoText;

    Vector3 lookDirection;

    //Gun Variables
    [SerializeField]
    private GameObject bullet;
    private bool shooting;
    public int shots;
    private int OriginalShots;


    private void Awake()
    {
        movePlayer = new NewControls();
        starting = transform.position;
        shooting = false;
        OriginalShots = shots;
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
        if(health <= 0)
        {
            transform.position = starting;
            health = 100;
        }

        moveDirection = movement.ReadValue<Vector2>();
        transform.position += new Vector3(moveDirection.x, 0, moveDirection.y) * Time.deltaTime * moveSpeed;


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

    private void DodgeRoll(InputAction.CallbackContext context)
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
    }
}
