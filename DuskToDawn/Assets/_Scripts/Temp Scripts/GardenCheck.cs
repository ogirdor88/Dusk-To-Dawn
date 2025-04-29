using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenCheck : MonoBehaviour
{
    public GameObject AcrobatUp, WeaponUp, SurvivalUp;
    void Update()
    {
        if (PlayerPrefs.GetString("FasterDash") == "Got")
        {
            Destroy(AcrobatUp.GetComponent<AcrobatUpgrade>().button2);
            //AcrobatUp.GetComponent<AcrobatUpgrade>()gameObject.SetActive(false);
        }
        
        if (PlayerPrefs.GetString("FasterKey") == "Got")
        {
            Destroy(AcrobatUp.GetComponent<AcrobatUpgrade>().button1);
        }

        if (PlayerPrefs.GetString("GlassTrap") == "Got")
        {
            Destroy(AcrobatUp.GetComponent<AcrobatUpgrade>().button3);
        }

        if (PlayerPrefs.GetString("MoreStamina") == "Got")
        {
            Destroy(AcrobatUp.GetComponent<AcrobatUpgrade>().button4);
        }

        if (PlayerPrefs.GetString("MoreAmmo") == "Got")
        {
            Destroy(WeaponUp.GetComponent<WeaponUpgrade>().button1);
            
        }

        if (PlayerPrefs.GetString("ZombieAmmo") == "Got")
        {
            Destroy(WeaponUp.GetComponent<WeaponUpgrade>().button2);

        }
        if (PlayerPrefs.GetString("Bullet") == "Got")
        {
            Destroy(WeaponUp.GetComponent<WeaponUpgrade>().button3);

        }

        if (PlayerPrefs.GetString("Instakill") == "Got")
        {
            Destroy(WeaponUp.GetComponent<WeaponUpgrade>().button4);

        }

        if (PlayerPrefs.GetString("Health1") == "Got")
        {
            Destroy(SurvivalUp.GetComponent<SurvivalistUpgrades>().button1);

        }

        if (PlayerPrefs.GetString("Health2") == "Got")
        {
            Destroy(SurvivalUp.GetComponent<SurvivalistUpgrades>().button2);

        }
    }
}
