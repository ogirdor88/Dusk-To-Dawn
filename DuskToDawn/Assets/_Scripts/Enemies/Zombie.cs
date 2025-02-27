using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float speed;

    private bool followPlayer;

    private int health = 8;

    public CustomTrigger detectionTrigger;
    public CustomTrigger bodyTrigger;


    private void Awake()
    {
        detectionTrigger.EnteredTrigger += OndetectionTriggerEntered;
        //detectionTrigger.ExitedTrigger += OndetectionTriggerExited;
        bodyTrigger.EnteredTrigger += OnbodyTriggerEntered;
        //bodyTrigger.ExitedTrigger -= OnbodyTriggerExited;
    }
    // Start is called before the first frame update
    void Start()
    {
        followPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            Getem();
        }

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
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
            health -= 4;
        }
    }
    /*private void OnbodyTriggerExited(Collider other)
    {

    }*/
}
