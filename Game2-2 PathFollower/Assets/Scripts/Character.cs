using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private List<Waypoint> path;
    private List<Waypoint> savedPath;
    private int current;
    private Ray ray;
    private bool mouseClicked;
    private int savedCurrent;

    public Waypoint start;
    public float threshold;

    void Start()
    {
        path = Pathfinding.BreadthhwisePatroll(start);
        current = 0;
        StartCoroutine(CheckDistance());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(path[current].transform);
        transform.Translate(transform.forward * Time.deltaTime * 5, Space.World);

        if (Input.GetMouseButtonDown(0) && !mouseClicked)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                mouseClicked = true;
                savedCurrent = current;
                float distance = float.MaxValue;
                int newCurrent = -1;

                for (int i = 0; i < path.Count; i++)
                {
                    float d = Vector3.Distance(hit.point, path[i].transform.position);
                    if (d < distance)
                    {
                        distance = d;
                        newCurrent = i;
                    }
                }
                
                savedPath = path;
                path = Pathfinding.Breadthhwise(path[current], path[newCurrent]);
                current = 0;
                string test = "";
                foreach (Waypoint w in path)
                {
                    test += (w.transform.name + "-->");
                }
                print(test);


            }
        }

    }

    IEnumerator CheckDistance()
    {
        while (true)
        {
            //check distance
            float d = Vector3.Distance(transform.position, path[current].transform.position);
            if (d < threshold)
            {

                current++;
                if (current >= path.Count && !mouseClicked)
                {
                    current %= path.Count;
                }
                else if(current >= path.Count)
                {
                    mouseClicked = false;
                    current = savedCurrent;
                    path = savedPath;
                }
            }
            // wait
            yield return new WaitForSeconds(0.1f);
        }
    }
}
