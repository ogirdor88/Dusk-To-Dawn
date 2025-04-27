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
        if (Experience.currentLVL >= 1)
        {
            Destroy(button1);
            PlayerMovement.health += 25f;
            PlayerMovement.maxHealth += 25f;
            Experience.currentLVL -= 1;
            PlayerPrefs.SetString("Health1", "Got");
        }
    }

    public void IncreaseHealth2()
    {
        if (Experience.currentLVL >= 2)
        {
            Destroy(button2);
            PlayerMovement.health += 25f;
            PlayerMovement.maxHealth += 25f;
            Experience.currentLVL -= 2;
            PlayerPrefs.SetString("Health2", "Got");
        }
    }



}
