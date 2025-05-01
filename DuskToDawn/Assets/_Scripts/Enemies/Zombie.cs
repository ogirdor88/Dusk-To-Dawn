using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    private GameObject target, attackBox, followrange, ammoBoxDrop;

    [SerializeField]
    private float speed, attackDelay;


    private bool followPlayer, attackPlayer;
    
    [SerializeField]
    private int health = 8;
    public static bool zombieUpgrade;

    public CustomTrigger detectionTrigger;
    public CustomTrigger bodyTrigger;
    public CustomTrigger attackTrigger;

    //ZombieAnimation
    private Animator anim;
    public GameObject ZombieRig;


    //Zombie Instakill
    public static bool instakill = false;

    private void Awake()
    {
        detectionTrigger.EnteredTrigger += OndetectionTriggerEntered;
        //detectionTrigger.ExitedTrigger += OndetectionTriggerExited;
        bodyTrigger.EnteredTrigger += OnbodyTriggerEntered;
        //bodyTrigger.ExitedTrigger -= OnbodyTriggerExited;
        attackTrigger.EnteredTrigger += OnattackTriggerEntered;
        attackTrigger.StayTrigger += OnattackTriggerStay;

        followPlayer = false;
        attackPlayer = false;
        attackBox.SetActive(false);

        anim = ZombieRig.GetComponent<Animator>();

        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            anim.SetBool("isWalking", true);
            Getem();
        }




        if(health <= 0)
        {
            Experience.currentEXP += 5;
            Destroy(this.gameObject);
            if (zombieUpgrade)
            {
                Instantiate(ammoBoxDrop, transform.position, Quaternion.identity);
            }
        }

        anim.SetBool("isWalking", false);
    }

    private void Getem()
    {
        transform.LookAt(target.transform.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            followPlayer=true;
        }
    }

    private void OndetectionTriggerEntered(Collider other)
    {
        if (other.tag == "Player")
        {
            followPlayer = true;
        }
    }
    /*private void OndetectionTriggerExited(Collider other)
    {

    }*/

    private void OnbodyTriggerEntered(Collider other)
    {
        if (other.tag == "Bullet")
        {
            if (instakill)
            {
                int randy = Random.Range(0, 20);
                if (randy % 5 == 0) {
                    health -= 20;
                }
            }
            else
            {
                health -= 4;
            }
        }
        if (other.tag == "Melee")
        {
            health -= 1;
        }
    }
    /*private void OnbodyTriggerExited(Collider other)
    {

    }*/

    private void OnattackTriggerEntered(Collider other)
    {
        //when the player enter the attack range have the follow stop so that the player can try to get away
        //make the enemy attack
        //set the attack bool to false;
        if (other.tag == "Player")
        {
            
            followPlayer = false;
            followrange.SetActive(false);
            if(!attackPlayer) 
            {
                StartCoroutine(AttackTime());
            }
            
        }
    }
    private void OnattackTriggerStay(Collider other)
    {
        //when the player enter the attack range have the follow stop so that the player can try to get away
        //make the enemy attack
        //set the attack bool to false;
        if (other.tag == "Player")
        {
            if (!attackPlayer)
            {
                StartCoroutine(AttackTime());
            }

        }
    }

    private IEnumerator AttackTime()
    {
        float speedhold = speed;
        speed = 0;
        attackPlayer = true;
        attackBox.SetActive(true);
        yield return new WaitForSeconds(attackDelay);
        attackBox.SetActive(false);
        attackPlayer = false;
        speed = speedhold;
    }
}
