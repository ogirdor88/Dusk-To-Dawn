using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScanner : MonoBehaviour
{

    public GameObject iuef;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            this.gameObject.transform.position = iuef.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Highlight")
         {
            Debug.Log("iufeijeoe");
         }
    }

}
