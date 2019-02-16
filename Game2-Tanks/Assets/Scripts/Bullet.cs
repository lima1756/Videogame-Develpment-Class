using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas canvas;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * 5, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Brick" || collision.collider.tag == "Tank")
        {
            rb.AddExplosionForce(10000, collision.transform.position, 20);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            
            if(collision.collider.tag == "Tank")
            {
                Instantiate(canvas);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Delete")
        {
            Destroy(this.gameObject);
        }
    }
}
