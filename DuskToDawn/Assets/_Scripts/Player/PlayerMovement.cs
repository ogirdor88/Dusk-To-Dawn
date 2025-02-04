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

    [SerializeField]
    private float moveSpeed;

    Vector3 mousePosition;
    Vector3 lookDirection;


    private void Awake()
    {
        movePlayer = new NewControls();
    }

    private void OnEnable()
    {
        movement = movePlayer.Player.Movement;
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }


    private void Update()
    {
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

    private void PlayerTurn()
    {

    }
}
