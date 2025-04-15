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
    
    
    public void MoreAmmoCapacity()
    {
        //GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().shots += 4;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().OriginalShots += 4;
    }

    public void ZombieAmmoDrop()
    {
        //GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().shots += 4;
        Zombie.zombieUpgrade = true;
    }

}

