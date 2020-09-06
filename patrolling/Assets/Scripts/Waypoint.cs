using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public Waypoint[] neighbors;
    public List<Waypoint> history;
    public float g, h;

    public float F
    {
        get
        {
            return g + h;
        }
    }
    // Start is called before the first frame update
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
        Gizmos.DrawSphere(transform.position, 1);

        Gizmos.color = Color.yellow;
        foreach (Waypoint waypoint in neighbors)
        {
            Gizmos.DrawLine(transform.position, waypoint.transform.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 1);
    }
}
