using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class RatSpawn : MonoBehaviour
{
    [SerializeField]
    private int health = 8;
    [SerializeField]
    private GameObject rat;
    private bool canRat;
    [SerializeField]
    private float spawnDelay;

    public CustomTrigger bodyTrigger;
    public CustomTrigger attackTrigger;

    private void Awake()
    {
        canRat = false;
        bodyTrigger.EnteredTrigger += OnbodyTriggerEntered;
        attackTrigger.EnteredTrigger += OnattackTriggerEntered;
        attackTrigger.StayTrigger += OnattackTriggerStay;
    }

    // Update is called once per frame
    void Update()
    {
        //if the ratkings health reaches 0 destroy the ratking and give experience
        if (health <= 0)
        {
            Experience.currentEXP += 5;
            Destroy(this.gameObject);
        }
    }

    //sets the bool to true and spawns a rat
    //waits for a spawn delay 
    //sets the bool back to false so that the next rat will spawn
    private IEnumerator SpawnRat()
    {
        canRat = true;
        Instantiate(rat, transform.position, transform.rotation);
        yield return new WaitForSeconds(spawnDelay);
        canRat = false;
    }

    private void OnattackTriggerEntered(Collider other)
    {
        //when the player enter the attack range start the rat spawning
        if (other.tag == "Player")
        {
            if (!canRat)
            {
                StartCoroutine(SpawnRat());
                Debug.Log("Rats");
            }
        }
    }
    private void OnattackTriggerStay(Collider other)
    {
        //if the player stays in the attack zone keep spawning rats
        if (other.tag == "Player")
        {
            if (!canRat)
            {
                StartCoroutine(SpawnRat());
                Debug.Log("Rats");
            }
        }
    }

    //if a bullet or a melee attack enters the body hitbox take health away
    private void OnbodyTriggerEntered(Collider other)
    {
        if (other.tag == "Bullet")
        {
            health -= 4;
        }
        if (other.tag == "Melee")
        {
            health -= 1;
        }
    }
}
