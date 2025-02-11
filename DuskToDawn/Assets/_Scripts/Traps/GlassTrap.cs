using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassTrap : MonoBehaviour
{
    [SerializeField]
    private float damage;

    private void Awake()
    {
        //for testing - set the color of the trap to differentiate objects
        this.GetComponent<Renderer>().material.color = Color.blue;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerMovement.health = PlayerMovement.health - (damage * Time.deltaTime);
            Debug.Log(PlayerMovement.health);
        }
    }
}
