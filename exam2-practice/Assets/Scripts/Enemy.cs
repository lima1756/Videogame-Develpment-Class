using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Waypoint[] waypoints;
    private NavMeshAgent agent;
    public Player player;
    private int current;
    private bool followPlayer;
    void Start()
    {
        current = 0;
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(CheckDistanceWaypoint());
        StartCoroutine(CheckDistancePlayer());
        followPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            agent.destination = player.transform.position;
        }
        else {
            agent.destination = waypoints[current].transform.position;
        }
    }

    IEnumerator CheckDistanceWaypoint()
    {
        while (true)
        {
            float distance = Vector3.Distance(transform.position, waypoints[current].transform.position);
            if (distance < 1f && !followPlayer)
            {
                current++;
                current %= waypoints.Length;
            }
            yield return new WaitForSeconds(.3f);
        }
    }

    IEnumerator CheckDistancePlayer()
    {
        while (true)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            followPlayer = distance < 5f;
            yield return new WaitForSeconds(.3f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, .3f);
    }
}
