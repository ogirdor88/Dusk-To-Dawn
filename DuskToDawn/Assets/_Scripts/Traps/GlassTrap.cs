using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassTrap : MonoBehaviour
{
    //[SerializeField]
    public static float damage = 5;

    private void Awake()
    {
        //for testing - set the color of the trap to differentiate objects
        this.GetComponent<Renderer>().material.color = Color.blue;
    }
    private void OnTriggerStay(Collider other)
    {
        //if the player touches the glass trap they will start to take damage per second while they are standing on the trap
        if(other.tag == "Player")
        {
            PlayerMovement.health = PlayerMovement.health - (damage * Time.deltaTime);
            Debug.Log(PlayerMovement.health);
        }
    }
}
