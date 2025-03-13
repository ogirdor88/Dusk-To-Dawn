using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{

    [SerializeField]
    private Animator doorAnim;

    [SerializeField]
    private bool openTrigger = false;
    [SerializeField]
    private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            if (openTrigger)
            {
                doorAnim.Play("DoorOpen", 0, 0);
            }
            /*
            else if (closeTrigger)
            {
                doorAnim.Play("DoorClose", 0, 0);
            }
            */
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                doorAnim.Play("DoorClose", 0, 0);
            }
            /*
            else if (closeTrigger)
            {
                doorAnim.Play("DoorClose", 0, 0);
            }*/
        }
    }
}
