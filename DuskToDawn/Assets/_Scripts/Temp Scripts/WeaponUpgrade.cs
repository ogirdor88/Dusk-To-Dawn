using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{

    [SerializeField]
    private GameObject playerObject;
    
    
    [TextArea]
    public string Notes = "1 = More Ammo Cap";
    
    [SerializeField]
    private int upgradeTree;
    
    private void Start()
    { }

    private void Update()
    {
        WeaponTree();
    }

    

    private void WeaponTree()
    {
        switch (upgradeTree)
        {
            case 0:
                break;
            case 1:
                MoreAmmoCapacity();
                upgradeTree = 0;
                break;
            case 2:
                
                upgradeTree = 0;
                break; 
            case 3:
                
                upgradeTree = 0;
                break;
            case 4:
                
                upgradeTree = 0;
                break;
            default:
                break;
        }
    }


    private void MoreAmmoCapacity()
    {
        //GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().shots += 4;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().OriginalShots += 4;
    }

}

