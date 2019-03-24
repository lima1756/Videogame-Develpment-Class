using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public Bullet bullet;
    float nextShot;
    // Start is called before the first frame update
    void Start()
    {
        nextShot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShot)
        {
            float pos = Mathf.Clamp(Random.value*18-9, -8, 8); 
            nextShot = Time.time + .75f;
            Bullet b = Instantiate(bullet, new Vector3(pos,5,-1), bullet.transform.rotation);
            b.transform.tag = "BulletWall";
            Destroy(b.gameObject, 1.5f);
        }
    }
}