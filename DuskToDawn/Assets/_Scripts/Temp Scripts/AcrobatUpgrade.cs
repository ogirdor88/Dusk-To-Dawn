using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcrobatUpgrade : MonoBehaviour
{

    public static AcrobatUpgrade Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField]
    private GameObject playerObject;

    PlayerMovement pm;
    
    
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


    public void Faster()
    {
        //playerObject.GetComponent<PlayerMovement>().normSpeed *= 1.5f;
       PlayerMovement.normSpeed *= 1.5f;
        Debug.Log("HAHHHHHAHHHHHHHHHHH");
    }

    public void GlassTrapDamageReduction()
    {
        GlassTrap.damage = 2;
    }

    public void FasterDash()
    { 
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().dashSpeed = 18f;
       
    }

    public void DashForLonger()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().dashTime = 0.15f;   
    }


}

