using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    [SerializeField]
    private float damage, holdTime;

    public static bool holding;
    private float playerspeed;

    private void Awake()
    {
        //for testing - set the color of the trap to differentiate objects
        //this.GetComponent<Renderer>().material.color = Color.red;

        holding = false;

        //save the players move speed for later
        playerspeed = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the player steps in the trap
        //damage the player
        //change the players position to the center of the trap
        //start a timer for how long the player will be stuck in the trap
        if (other.tag == "Player")
        {
            Debug.Log("Trapped " + playerspeed );
            holding = true;
            PlayerMovement.health = PlayerMovement.health - damage;
            Debug.Log(PlayerMovement.health);
            if (holding)
            {
                other.gameObject.transform.position = new Vector3( this.transform.position.x, other.transform.position.y, this.transform.position.z);
            }
            StartCoroutine(Grabbed());
        }

        if (other.tag == "Bullet")
        {
            Debug.Log("Trapped");
            this.gameObject.SetActive(false);

        }
    }


    //after the player leaves the trap have it disapear so that they dont step in the dissarmed trap
    private void OnTriggerExit(Collider other)
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().moveSpeed = playerspeed;
        this.gameObject.SetActive(false);
    }

    private IEnumerator Grabbed()
    {
        //set the players speed to 0 so they cant move
        //wait for the time to run out
        //set the players move speed back to the original speed
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().moveSpeed = 0;
        yield return new WaitForSeconds(holdTime);
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().moveSpeed = playerspeed;
        holding =false;
    }
}
