using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{

    [SerializeField]
    private GameObject playerObject;

    //[SerializeField]
    public GameObject button1, button2, button3, button4;

    [TextArea]
    public string Notes = "1 = More Ammo Cap";
    
    [SerializeField]
    private int upgradeTree;
    
    
    public void MoreAmmoCapacity()
    {
        if (Experience.currentLVL >= 1)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().OriginalShots += 4;
            Destroy(button1);
            Experience.currentLVL -= 1;
            PlayerPrefs.SetString("MoreAmmo", "Got");
        }
    }

    public void ZombieAmmoDrop()
    {
        //GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().shots += 4;
        if (Experience.currentLVL >= 1)
        {
            Zombie.zombieUpgrade = true;
            Destroy(button2);
            Experience.currentLVL -= 1;
            PlayerPrefs.SetString("ZombieAmmo", "Got");
        }
    }

    public void BulletNotSpent()
    {
        if (Experience.currentLVL >= 2)
        {
            Destroy(button3);
            PlayerMovement.bulletChance = true;
            PlayerMovement.regularShooting = false;
            Experience.currentLVL -= 2;
            PlayerPrefs.SetString("Bullet", "Got");
        }
    }

    public void InstaKillZombies()
    {
        if (Experience.currentLVL >= 2)
        {
            Destroy(button4);
            Zombie.instakill = true;
            Experience.currentLVL -= 2;
            PlayerPrefs.SetString("Instakill", "Got");
        }
    }

}

