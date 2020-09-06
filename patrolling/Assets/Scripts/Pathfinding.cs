using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    public static List<Waypoint> Breadthhwise(Waypoint start, Waypoint end)
    {
        Queue<Waypoint> queue = new Queue<Waypoint>();
        List<Waypoint> blackList = new List<Waypoint>();

        start.history = new List<Waypoint>();
        queue.Enqueue(start);
        while(queue.Count>0)
        {
            Waypoint current = queue.Dequeue();
            blackList.Add(current);
            if (current.Equals(end))
            {
                current.history.Add(current);
                return current.history;
            }
            foreach(Waypoint child in current.neighbors)
            {
                if (!blackList.Contains(child))
                {
                    queue.Enqueue(child);
                    child.history = new List<Waypoint>(current.history);
                    child.history.Add(current);
                }
            }
        }
        return null;
    }

    public static List<Waypoint> Depthwise(Waypoint start, Waypoint end)
    {
        Stack<Waypoint> stack = new Stack<Waypoint>();
        List<Waypoint> blackList = new List<Waypoint>();

        start.history = new List<Waypoint>();
        stack.Push(start);
        while (stack.Count > 0)
        {
            Waypoint current = stack.Pop();
            blackList.Add(current);
            if (current.Equals(end))
            {
                current.history.Add(current);
                return current.history;
            }
            foreach (Waypoint child in current.neighbors)
            {
                if (!blackList.Contains(child))
                {
                    stack.Push(child);
                    child.history = new List<Waypoint>(current.history);
                    child.history.Add(current);
                }
            }
        }
        return null;
    }

    public static List<Waypoint> AStar(Waypoint start, Waypoint end)
    {
        List<Waypoint> visited, work;
        visited = new List<Waypoint>();
        work = new List<Waypoint>();

        start.history = new List<Waypoint>();
        visited.Add(start);
        work.Add(start);

        start.g = 0;
        start.h = 0;

        while(work.Count > 0)
        {

            Waypoint actual = work[0];
            work.Remove(actual);
            for(int i =1; i< work.Count; i++)
            {
                if(work[i].F < actual.F)
                {
                    actual = work[i];
                }
            }

            foreach(Waypoint currentNeighbor in actual.neighbors)
            {
                if (!visited.Contains(currentNeighbor))
                {
                    if (currentNeighbor == end)
                    {
                        List<Waypoint> result = actual.history;
                        result.Add(currentNeighbor);
                        return result;
                    }

                    currentNeighbor.g = actual.g + Vector3.Distance(actual.transform.position, currentNeighbor.transform.position);
                    currentNeighbor.h = Vector3.Distance(currentNeighbor.transform.position, end.transform.position);

                    currentNeighbor.history = new List<Waypoint>(actual.history);
                    currentNeighbor.history.Add(actual);

                    visited.Add(currentNeighbor);
                    work.Add(currentNeighbor);

                }
            }

        }
        return null;
    }
}
