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
        playerspeed = 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Trapped");
            holding = true;
            if(holding)
            {
                other.gameObject.transform.position = this.transform.position;
            }
            StartCoroutine(Grabbed());

        }
    }

    private IEnumerator Grabbed()
    {
        yield return new WaitForSeconds(holdTime);
        holding=false;
    }
}
