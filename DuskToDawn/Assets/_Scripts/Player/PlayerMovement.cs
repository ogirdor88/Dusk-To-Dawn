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
    private float dashSpeed, dashTime;

    [SerializeField]
    private TMP_Text healthText;

    Vector3 mousePosition;
    Vector3 lookDirection;

    [SerializeField]
    private GameObject bullet;


    private void Awake()
    {
        movePlayer = new NewControls();
        starting = transform.position;
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
        SetHealth();
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
            if (hit.collider.CompareTag("Ground"))
            {
                lookDirection = hit.point - transform.position;
                lookDirection.y = 0;

                transform.LookAt(new Vector3(lookDirection.x, transform.position.y, lookDirection.z));
            }
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

    private void SetHealth()
    {
        healthText.SetText("Player Health:" + Convert.ToInt32(health));
    }

    private void DamageTime(InputAction.CallbackContext context )
    {
        Shooting();
    }

    private void Shooting()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
