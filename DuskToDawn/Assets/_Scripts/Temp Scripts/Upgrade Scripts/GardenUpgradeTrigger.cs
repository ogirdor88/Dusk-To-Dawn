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
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().hasGun = false;
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().knifeMode = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            upgradeCanvas.SetActive(false);
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().knifeMode = true;
        }
    }
}
