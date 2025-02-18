using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClippingZone : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> items;

    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player)")
        {
            Debug.Log("Player");
            for (int i = 0; i < items.Count; i++) 
            {
                items[i].transform.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        //if the player touches the glass trap they will start to take damage per second while they are standing on the trap
        if (other.tag == "Player")
        {
            Debug.Log("Player");
            for (int i = 0; i < items.Count; i++)
            {
                items[i].transform.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player");
        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
