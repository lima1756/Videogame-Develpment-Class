using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    public static LinkedList<Waypoint> Breadthhwise(Waypoint start, Waypoint end)
    {
        Queue<Waypoint> queue = new Queue<Waypoint>();
        LinkedList<Waypoint> blackList = new LinkedList<Waypoint>();

        start.history = new LinkedList<Waypoint>();
        queue.Enqueue(start);
        while(queue.Count>0)
        {
            Waypoint current = queue.Dequeue();
            blackList.AddLast(current);
            if (current.Equals(end))
            {
                current.history.AddLast(current);
                return current.history;
            }
            foreach(Waypoint child in current.neighbors)
            {
                if (!blackList.Contains(child))
                {
                    queue.Enqueue(child);
                    child.history = new LinkedList<Waypoint>(current.history);
                    child.history.AddLast(current);
                }
            }
        }
        return null;
    }

    public static LinkedList<Waypoint> Depthwise(Waypoint start, Waypoint end)
    {
        Stack<Waypoint> stack = new Stack<Waypoint>();
        LinkedList<Waypoint> blackList = new LinkedList<Waypoint>();

        start.history = new LinkedList<Waypoint>();
        stack.Push(start);
        while (stack.Count > 0)
        {
            Waypoint current = stack.Pop();
            blackList.AddLast(current);
            if (current.Equals(end))
            {
                current.history.AddLast(current);
                return current.history;
            }
            foreach (Waypoint child in current.neighbors)
            {
                if (!blackList.Contains(child))
                {
                    stack.Push(child);
                    child.history = new LinkedList<Waypoint>(current.history);
                    child.history.AddLast(current);
                }
            }
        }
        return null;
    }

    public static LinkedList<Waypoint> AStar(Waypoint start, Waypoint end)
    {
        return null;
    }
}
