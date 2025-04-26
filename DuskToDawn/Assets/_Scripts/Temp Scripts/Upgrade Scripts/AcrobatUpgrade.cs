using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcrobatUpgrade : MonoBehaviour
{

    [SerializeField]
    private GameObject playerObject;

    
    public GameObject button1, button2, button3, button4;

    PlayerMovement pm;
    
    
    [TextArea]
    public string Notes = "1 = Faster, 2 = Glass Trap Damage Reduction, 3 = Faster Dash Speed, 4 = Dash for longer";
    
    [SerializeField]
    private int upgradeTree;

    public void Faster()
    {
        if (Experience.currentLVL >= 1)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().normSpeed *= 1.1f;
            Destroy(button1);
            Experience.currentLVL -= 1;
            //UpgradeHolder.fasterKey = "Got";
            PlayerPrefs.SetString("FasterKey", "Got");
        } 
        
    }

    public void GlassTrapDamageReduction()
    {
        if (Experience.currentLVL >= 2)
            GlassTrap.damage = 2; Destroy(button3); Experience.currentLVL -= 2; PlayerPrefs.SetString("GlassTrap", "Got");
    }

    public void FasterDash()
    {
        if(Experience.currentLVL >= 1)
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().dashSpeed = 11.5f; Destroy(button2); Experience.currentLVL -= 1; PlayerPrefs.SetString("FasterDash", "Got");
    }

    public void MoreMaxStamina()
    {
        if (Experience.currentLVL >= 2)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().maxStamina = 75;
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().stamina = 75;
            Destroy(button4);
            Experience.currentLVL -= 2;
            PlayerPrefs.SetString("MoreStamina", "Got");
        }

    }

}

