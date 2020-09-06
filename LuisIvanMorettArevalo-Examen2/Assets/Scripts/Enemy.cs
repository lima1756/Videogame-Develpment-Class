using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Waypoint[] waypoints;
    public bool chase;
    private Waypoint[] savedWaypoints;
    private int current;
    private int savedCurrent;
    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        StartCoroutine(CheckDistance());
        chase = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(waypoints[current].transform.position);
        transform.Translate(transform.forward * Time.deltaTime * 5, Space.World);
    }

    public void ChangePath(Waypoint end)
    {
        chase = true;
        print("-----Chase started----");
        savedWaypoints = waypoints;
        savedCurrent = current;
        Queue<Waypoint> queue = new Queue<Waypoint>();
        List<Waypoint> blackList = new List<Waypoint>();
        List<Waypoint> history = new List<Waypoint>();
        
        queue.Enqueue(waypoints[current]);

        while (queue.Count > 0)
        {
            Waypoint currentWaypoint = queue.Dequeue();
            history.Add(currentWaypoint);
            blackList.Add(currentWaypoint);
            print(currentWaypoint.transform.name + "-->");
            if (currentWaypoint == end) {
                waypoints = history.ToArray();
                current = 0;
                return;
            }
            foreach(Waypoint neighbor in currentWaypoint.neighbors)
            {
                if (!blackList.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                }
            }
            
        }

    }

    IEnumerator CheckDistance()
    {
        while (true)
        {
            float distance = Vector3.Distance(transform.position, waypoints[current].transform.position);
            if (distance < .1f)
            {
                current++;
                if (chase && current == waypoints.Length)
                {
                    current = savedCurrent;
                    waypoints = savedWaypoints;
                    chase = false;
                }
                else
                    current %= waypoints.Length;
            }
            yield return new WaitForSeconds(.3f);
        }
    }
}
