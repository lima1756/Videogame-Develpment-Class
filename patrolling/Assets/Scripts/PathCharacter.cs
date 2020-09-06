using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    private List<Waypoint> path;
    private int current;
    void Start()
    {
        //path = Pathfinding.Breadthhwise(start, end);
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(path[current].transform);
        transform.Translate(transform.forward * Time.deltaTime * 5, Space.World);
    }
}
