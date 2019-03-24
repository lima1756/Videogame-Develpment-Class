using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // stalker

    public Waypoint[] path;
    public float threshold;

    private int current;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        StartCoroutine(CheckDistance());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(path[current].transform);
        transform.Translate(transform.forward * Time.deltaTime * 5, Space.World);
    }

    IEnumerator CheckDistance()
    {
        while (true)
        {
            //check distance
            float d = Vector3.Distance(transform.position, path[current].transform.position);
            if (d < threshold)
            {
                current = (current + 1) % path.Length;
            }
            // wait
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnMouseEnter()
    {
        print("mouse enter");
    }

    private void OnMouseDown()
    {
        print("mouse down");
    }
    private void OnMouseDrag()
    {
        
    }

    private void OnMouseExit()
    {
        
    }

    private void OnMouseOver()
    {
        
    }

    private void OnMouseUp()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        
    }
}
