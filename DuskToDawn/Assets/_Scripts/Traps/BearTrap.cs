using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    [SerializeField]
    private float damage, holdTime;

    private bool holding;

    private void Awake()
    {
        //for testing - set the color of the trap to differentiate objects
        this.GetComponent<Renderer>().material.color = Color.green;

        holding = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Trapped");
        }
    }
}
