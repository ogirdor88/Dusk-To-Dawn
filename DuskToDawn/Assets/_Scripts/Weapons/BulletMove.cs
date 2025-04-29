using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
        StartCoroutine(DestroyBullet());
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5);
        Destroy( this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie")
        {
            Destroy(this.gameObject);
        }
        if (other.tag == "Wisp")
        {
            Destroy(this.gameObject);
        }
        /*if (other.tag == "Rat")
        {
            Destroy(this.gameObject);
        }*/
        if (other.tag == "RatKing")
        {
            Destroy(this.gameObject);
        }
        if (other.tag == "wall")
        {
            Debug.Log("Wall");
            Destroy(this.gameObject);
        }
    }
}
