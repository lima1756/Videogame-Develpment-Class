using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{

    public float speed = 10;
    public GameObject bullet;
    public Transform bulletStart;
    private bool lastShoot;
    private int totalLife;
    public Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        lastShoot = false;
        totalLife = 100;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(0, vertical * Time.deltaTime * speed, horizontal * Time.deltaTime* speed);
        bool shoot = Input.GetAxis("Jump") == 1;
        if (shoot && !lastShoot)
        {
            Instantiate(bullet, bulletStart.position, new Quaternion());
        }
        lastShoot = shoot;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            this.totalLife -= 1;
            UpdateText();
        }
    }

    private void UpdateText()
    {
        this.text.text = "Life: " + this.totalLife;
    }
}


