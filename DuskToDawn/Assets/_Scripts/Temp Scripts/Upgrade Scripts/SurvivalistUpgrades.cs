using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalistUpgrades : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    [SerializeField]
    private GameObject checkenemy;


    [TextArea]
    public string Notes = "1 = Health Increase, 2 = Health More Increased,";

    [SerializeField]
    private int upgradeTree;

    public void IncreaseHealth()
    {
        PlayerMovement.health += 25f;
        PlayerMovement.maxHealth += 25f;
    }

   

}
