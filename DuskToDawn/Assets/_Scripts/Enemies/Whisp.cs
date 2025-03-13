using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whisp : MonoBehaviour
{

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float attackDelay;


    private bool attackPlayer;

    private int health = 8;

    public CustomTrigger detectionTrigger;
    public CustomTrigger bodyTrigger;

    // Start is called before the first frame update
    void Start()
    {
        detectionTrigger.EnteredTrigger += OndetectionTriggerEntered;
        //detectionTrigger.ExitedTrigger += OndetectionTriggerExited;
        bodyTrigger.EnteredTrigger += OnbodyTriggerEntered;
        //bodyTrigger.ExitedTrigger -= OnbodyTriggerExited;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Experience.currentEXP += 5;
            Destroy(this.gameObject);
        }
    }

    //when the player gets in range the whisp will begin firing projectiles at them
    private void OndetectionTriggerEntered(Collider other)
    {
        if (other.tag == "Player")
        {
            //shoot the player
            if (!attackPlayer)
            {

            }
        }
    }

    //if the whisp is hit it will lose health then teleport
    private void OnbodyTriggerEntered(Collider other)
    {
        if (other.tag == "Bullet")
        {
            health -= 4;
            //teleport the whisp
        }
    }
}
