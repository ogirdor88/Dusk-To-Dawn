using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalistUpgrades : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;


    [TextArea]
    public string Notes = "1 = Health Increase, 2 = Health More Increased,";

    [SerializeField]
    private int upgradeTree;

    private void Start()
    { }

    private void Update()
    {
        SurvivalistTree();
    }

    private void SurvivalistTree()
    {
        switch (upgradeTree)
        {
            case 0:
                break;
            case 1:
                IncreaseHealth();
                upgradeTree = 0;
                break;
            case 2:
                IncreaseHealth();
                upgradeTree = 0;
                break;
            default:
                break;
        }
    }

    private void IncreaseHealth()
    {
        PlayerMovement.health += 25f;
    }

}
