using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    [SerializeField]
    private float damage, holdTime;

    private bool holding;
    private float playerspeed;

    private void Awake()
    {
        //for testing - set the color of the trap to differentiate objects
        this.GetComponent<Renderer>().material.color = Color.green;

        holding = false;
        playerspeed = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Trapped");
            holding = true;
            PlayerMovement.health = PlayerMovement.health - damage;
            Debug.Log(PlayerMovement.health);
            if (holding)
            {
                other.gameObject.transform.position = this.transform.position;
            }
            StartCoroutine(Grabbed());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        this.gameObject.SetActive(false);
    }

    private IEnumerator Grabbed()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().moveSpeed = 0;
        yield return new WaitForSeconds(holdTime);
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().moveSpeed = playerspeed;
        holding =false;
    }
}
