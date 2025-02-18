using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDirection;
    public NewControls movePlayer;
    private InputAction movement;
    private InputAction dash;

    private Vector3 starting;

    public float moveSpeed;
    public static float health = 100;

    [SerializeField]
    private float dashSpeed, dashTime;

    Vector3 mousePosition;
    Vector3 lookDirection;


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
    }

    private void OnDisable()
    {
        movement.Disable();
    }


    private void Update()
    {
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

            lookDirection = hit.point - transform.position;

            transform.LookAt(hit.point);
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
}
