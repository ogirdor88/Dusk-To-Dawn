using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcrobatUpgrade : MonoBehaviour
{

    [SerializeField]
    private GameObject playerObject;
    
    
    [TextArea]
    public string Notes = "1 = Faster, 2 = Glass Trap Damage Reduction, 3 = Faster Dash Speed, 4 = Dash for longer";
    
    [SerializeField]
    private int upgradeTree;
    
    private void Start()
    { }

    private void Update()
    {
        AcrobatTree();
    }

    

    private void AcrobatTree()
    {
        switch (upgradeTree)
        {
            case 0:
                break;
            case 1:
                Faster();
                upgradeTree = 0;
                break;
            case 2:
                GlassTrapDamageReduction();
                upgradeTree = 0;
                break; 
            case 3:
                FasterDash();
                upgradeTree = 0;
                break;
            case 4:
                DashForLonger();
                upgradeTree = 0;
                break;
            default:
                break;
        }
    }


    private void Faster()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().moveSpeed *= 1.5f;
    }

    private void GlassTrapDamageReduction()
    {
        GlassTrap.damage = 2;
    }

    private void FasterDash()
    { 
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().dashSpeed = 65f;
       
    }

    private void DashForLonger()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().dashTime = 0.15f;   
    }

}

