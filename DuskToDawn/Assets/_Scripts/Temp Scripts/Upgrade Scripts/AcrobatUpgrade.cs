using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcrobatUpgrade : MonoBehaviour
{

    [SerializeField]
    private GameObject playerObject;

    PlayerMovement pm;
    
    
    [TextArea]
    public string Notes = "1 = Faster, 2 = Glass Trap Damage Reduction, 3 = Faster Dash Speed, 4 = Dash for longer";
    
    [SerializeField]
    private int upgradeTree;

    public void Faster()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().normSpeed *= 1.5f;
        //playerObject.GetComponent<PlayerMovement>().normSpeed *= 1.5f;
       //PlayerMovement.normSpeed *= 1.5f;
        Debug.Log("HAHHHHHAHHHHHHHHHHH");
    }

    public void GlassTrapDamageReduction()
    {
        GlassTrap.damage = 2;
    }

    public void FasterDash()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().dashSpeed = 11.5f;
        //PlayerMovement.dashSpeed = 18f;       
    }

    public void MoreMaxStamina()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().maxStamina = 75;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().stamina = 75;

    }


}

