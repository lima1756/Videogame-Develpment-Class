using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * 15 , ForceMode.Impulse);
        //print(transform.up);
        //print(transform.forward);
        //print(transform.right);
        //rb.AddForce();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
