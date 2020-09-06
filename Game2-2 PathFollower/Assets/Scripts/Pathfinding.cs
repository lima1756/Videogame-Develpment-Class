using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    public static List<Waypoint> BreadthhwisePatroll(Waypoint start)
    {
        Queue<Waypoint> queue = new Queue<Waypoint>();
        List<Waypoint> blackList = new List<Waypoint>();

        List<Waypoint> history = new List<Waypoint>();
        queue.Enqueue(start);
        
        while (queue.Count > 0)
        {
            Waypoint current = queue.Dequeue();
            blackList.Add(current);
            history.Add(current);
            foreach (Waypoint child in current.neighbors)
            {
                if (!blackList.Contains(child) && !queue.Contains(child))
                {
                    queue.Enqueue(child);
                }
            }
        }
        return history;
    }

    public static List<Waypoint> Breadthhwise(Waypoint start, Waypoint end)
    {
        Queue<Waypoint> queue = new Queue<Waypoint>();
        List<Waypoint> blackList = new List<Waypoint>();

        List<Waypoint> history = new List<Waypoint>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            Waypoint current = queue.Dequeue();
            blackList.Add(current);
            history.Add(current);
            if(current == end)
            {
                return history;
            }
            foreach (Waypoint child in current.neighbors)
            {
                if (!blackList.Contains(child) && !queue.Contains(child))
                {
                    queue.Enqueue(child);
                }
            }
        }
        return null;
    }
}
