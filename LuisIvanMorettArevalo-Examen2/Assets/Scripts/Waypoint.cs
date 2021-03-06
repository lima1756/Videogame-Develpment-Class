﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint[] neighbors;
    public Enemy enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, .1f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!enemy.chase && other.transform.name == "Player")
        {
            enemy.ChangePath(this);
        }
    }

}
