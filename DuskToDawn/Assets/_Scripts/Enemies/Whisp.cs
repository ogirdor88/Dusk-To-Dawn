using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whisp : MonoBehaviour
{

    [SerializeField]
    private GameObject target, bullet, bulletSpawn, attackbox;

    [SerializeField]
    private float attackDelay;

    private bool shooting;
    private bool lockon;

    private int health = 8;

    public CustomTrigger detectionTrigger;
    public CustomTrigger bodyTrigger;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player");
        attackbox.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        detectionTrigger.EnteredTrigger += OndetectionTriggerEntered;
        //detectionTrigger.ExitedTrigger += OndetectionTriggerExited;
        bodyTrigger.EnteredTrigger += OnbodyTriggerEntered;
        //bodyTrigger.ExitedTrigger -= OnbodyTriggerExited;
        shooting = false;
        lockon = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(lockon)
        {
            Attack();
        }
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
            Debug.Log("GetThatGuy");
            lockon = true;
        }
    }

    //if the whisp is hit it will lose health then teleport
    private void OnbodyTriggerEntered(Collider other)
    {
        if (other.tag == "Bullet")
        {
            health -= 4;
            //teleport the whisp
            RandTeleport();
        }
    }

    private void RandTeleport()
    {
        Debug.Log("ouch");
        float randDist = Random.RandomRange(3f, 7f);
        Vector3 teleTarget = target.transform.position - target.transform.forward * randDist;

        transform.position = teleTarget;
    }

    private void Attack()
    {
        transform.LookAt(target.transform.position);
        //shoot the player
        if (!shooting)
        {
            StartCoroutine(Shooting());
        }
    }

    private IEnumerator Shooting()
    {
        Debug.Log("FireBall");
        shooting = true;
        StartCoroutine(ShootingDisplay());
        Instantiate(bullet, bulletSpawn.transform.position, transform.rotation);
        yield return new WaitForSeconds(attackDelay);
        shooting = false;
    }

    private IEnumerator ShootingDisplay()
    {
        attackbox.SetActive(false);
        yield return new WaitForSeconds(.5f);
        attackbox.SetActive(true);
    }
}
