using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalistUpgrades : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    //[SerializeField]
    public GameObject button1, button2, button3, button4;

    [SerializeField]
    private GameObject checkenemy;


    [TextArea]
    public string Notes = "1 = Health Increase, 2 = Health More Increased,";

    [SerializeField]
    private int upgradeTree;

    public void IncreaseHealth()
    {
        Destroy(button1);
        PlayerMovement.health += 25f;
        PlayerMovement.maxHealth += 25f;
    }

   

}
