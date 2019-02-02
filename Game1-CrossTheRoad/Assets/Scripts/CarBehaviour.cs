using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{

    public float speed = 4f;
    public int points = 10;
    public float cooldown = .5f;
    private float speedSave;
    private float direction;
    private int startPos;
    private float nextDamage;

    // Start is called before the first frame update
    void Start()
    {
        speedSave = speed;
        direction = 0;
        startPos = (int)Mathf.Abs(Mathf.Ceil(transform.position.x))+1;
        nextDamage = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime, Space.Self);
        if (transform.position.x > startPos || transform.position.x < -startPos)
        {
            transform.Rotate(0, (direction + 180) % 360, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "chicken")
        {
            //Debug.Log(this.name + " collision with " + other.name);
            speed = 0;
            MoveChicken.changePoints(-points);
            nextDamage = Time.time + cooldown;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "chicken" && Time.time > nextDamage)
        {
            MoveChicken.changePoints(-points/5);
            nextDamage = Time.time + cooldown;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "chicken")
        {
            speed = speedSave;
        }
    }
}
