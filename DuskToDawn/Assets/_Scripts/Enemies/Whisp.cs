using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Whisp : MonoBehaviour
{

    [SerializeField]
    private GameObject target, bullet, bulletSpawn, attackbox,rayObj;

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
    {/*
        if(lockon)
        {
            Attack();
        }*/
        Attack();
        if (health <= 0)
        {
            Experience.currentEXP += 5;
            Destroy(this.gameObject);
        }
        Ray ray;
        RaycastHit objectHit;
        Vector3 fwd = rayObj.transform.TransformDirection(Vector3.forward) *50;
        Debug.DrawRay(rayObj.transform.position, fwd , Color.green);
        if (Physics.Raycast(attackbox.transform.position, fwd, out objectHit))
        {
            if(objectHit.transform.CompareTag("Player"))
            {
                Debug.Log("looking at player");
                transform.LookAt(target.transform.position);
                //shoot the player
                if (!shooting)
                {
                    StartCoroutine(Shooting());
                }
            }
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
        if (other.tag == "Melee")
        {
            health -= 1;
            RandTeleport();
        }
    }

    private void RandTeleport()
    {
        Debug.Log("ouch");
        float randDist = Random.Range(3f, 7f);
        Vector3 teleTarget = target.transform.position - target.transform.forward * randDist;

        transform.position = teleTarget;
    }

    private void Attack()
    {
        transform.LookAt(target.transform.position);
        //shoot the player
        /*if (!shooting)
        {
            StartCoroutine(Shooting());
        }*/
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
