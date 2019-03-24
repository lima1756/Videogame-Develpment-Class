using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            for (int i = 0; i < 3; i++)
            {
                float random = Random.value * 50 - 25;
                Instantiate(enemy, new Vector3(-0.74f, random, -4.6f), new Quaternion());
            }
        }
    }
}
