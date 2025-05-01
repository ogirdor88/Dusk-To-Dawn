using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Whisp : MonoBehaviour
{

    [SerializeField]
    private GameObject target, bullet, bulletSpawn, attackbox,rayObj;

    [SerializeField]
    private float attackDelay;

    [SerializeField]
    private List<GameObject> teleportList;

    private bool shooting;
    private bool lockon;

    private int health;
    private int maxh = 16;

    public CustomTrigger detectionTrigger;
    public CustomTrigger bodyTrigger;

    //WispAnimation
    private Animator anim;
    public GameObject wispRig;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player");
        attackbox.SetActive(false);

        anim = wispRig.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        detectionTrigger.EnteredTrigger += OndetectionTriggerEntered;
        detectionTrigger.ExitedTrigger += OndetectionTriggerExited;
        bodyTrigger.EnteredTrigger += OnbodyTriggerEntered;
        //bodyTrigger.ExitedTrigger -= OnbodyTriggerExited;
        shooting = false;
        lockon = false;

        health = maxh;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(lockon)
        {
            anim.SetTrigger("Attack");
            Attack();
        }*/
        

        Attack();
        if (health <= 0)
        {
            Experience.currentEXP += 6;
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
    private void OndetectionTriggerExited(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("whereHeGo");
            lockon = false;
        }
    }

    //if the whisp is hit it will lose health then teleport
    private void OnbodyTriggerEntered(Collider other)
    {
        if (other.tag == "Bullet")
        {
            health -= 4;
            //teleport the whisp
            //RandTeleport();
            /*if (health <= (maxh / 2))
            {
                //RandTeleport();
                RandoTeleport();
            }*/
            RandoTeleport();
        }
        if (other.tag == "Melee")
        {
            health -= 1;
            //RandTeleport();
           /* if (health <= (maxh / 2))
            {
                RandTeleport();
            }*/
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

    private void RandoTeleport()
    {
        Debug.Log("ouch");
        int randDist = Random.Range(0, teleportList.Count);
        Vector3 teleTarget = new Vector3 (teleportList[randDist].transform.position.x, transform.position.y, teleportList[randDist].transform.position.z);

        transform.position = teleTarget;
    }
}
