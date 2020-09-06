using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(transform.up*1000, ForceMode.Acceleration);
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
