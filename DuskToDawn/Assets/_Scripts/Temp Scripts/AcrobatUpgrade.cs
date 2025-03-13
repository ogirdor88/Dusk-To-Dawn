using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcrobatUpgrade : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject, trapObject;

    [SerializeField]
    private int upgradeTree;

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
            default:
                break;
        }
    }

    private void Faster()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().moveSpeed *= 1.5f;
    }

    private void DashCooldownFaster()
    {
        //playerObject.GetComponent<PlayerMovement>(). *= 1.5f;
        //GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().moveSpeed;
        //trapObject.GetComponent<BearTrap>().damage = 4f;
    }

    private void GlassTrapDamageReduction()
    {
        //playerObject.GetComponent<PlayerMovement>(). *= 1.5f;
        //GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().dashSpeed = 6f;
        GlassTrap.damage = 2;
    }

}

