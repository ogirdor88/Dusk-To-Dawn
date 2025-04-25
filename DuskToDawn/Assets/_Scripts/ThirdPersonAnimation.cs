using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    public GameObject characterRig;
    public float maxSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = characterRig.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        print("I'm moving!");
        anim.SetFloat("Speed", rb.velocity.magnitude / maxSpeed);
    }
}
