using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private int direction; // 1 = right
    void Start()
    {
        direction = Random.value >= .5 ? 1 : -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, direction * Time.deltaTime * 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Bullet" || collision.transform.tag=="Ship")
        {
            Destroy(this.gameObject);
        }
        else
            direction *= -1;
    }
}
