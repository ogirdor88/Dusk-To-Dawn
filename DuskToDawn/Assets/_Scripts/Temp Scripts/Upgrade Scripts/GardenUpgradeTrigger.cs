using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenUpgradeTrigger : MonoBehaviour
{
    public GameObject upgradeCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            upgradeCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            upgradeCanvas.SetActive(false);
        }
    }
}
