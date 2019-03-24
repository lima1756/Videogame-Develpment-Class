using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{

    public float threshold;
    public Waypoint[] path;
    private int current = 0;
    private Animator animator;
    private bool die;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(CheckDistance());
    }

    // Update is called once per frame
    void Update()
    {
        if (!die)
        {
            transform.up = path[current].transform.position - transform.position;

            //transform.LookAt(new Vector3(path[current].transform.position.x, path[current].transform.position.z, 0));
            transform.Translate(transform.up * Time.deltaTime * 5, Space.World);
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
                current = (current + 1) % path.Length;
            }
            // wait
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            animator.SetTrigger("bullet_collision");
            die = true;
            Destroy(gameObject,1f);
        }
    }
}
