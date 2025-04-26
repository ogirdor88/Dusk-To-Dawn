using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject target, attackBox;
    [SerializeField]
    private float speed, attackDelay;


    private bool attackPlayer;

    [SerializeField]
    private int health = 1;
    public CustomTrigger bodyTrigger;
    public CustomTrigger attackTrigger;

    private void Awake()
    {
        bodyTrigger.EnteredTrigger += OnbodyTriggerEntered;
        //bodyTrigger.ExitedTrigger -= OnbodyTriggerExited;
        attackTrigger.EnteredTrigger += OnattackTriggerEntered;
        attackTrigger.StayTrigger += OnattackTriggerStay;
        attackPlayer = false;
        attackBox.SetActive(false);

        target = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {

        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (health <= 0)
        {
            Experience.currentEXP += 4;
            Destroy(this.gameObject);
        }
    }

    private void OnbodyTriggerEntered(Collider other)
    {
        /*if (other.tag == "Bullet")
        {
            health -= 4;
        }*/
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
            if (!attackPlayer)
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
