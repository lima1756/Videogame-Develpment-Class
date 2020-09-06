using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera camera;
    private Ray ray;
    private Animator animator;
    public Bullet bullet;
    float nextShot = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float straight = Input.GetAxis("Vertical");
        float sides = -Input.GetAxis("Horizontal");
        float shoot = Input.GetAxisRaw("Fire1");

        transform.Translate(straight * Time.deltaTime * 5, sides * Time.deltaTime * 5, 0);

        ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            transform.right = new Vector3(hit.point.x, hit.point.y,-1) - transform.position;
            if(shoot == 1 && Time.time > nextShot)
            {
                animator.SetTrigger("Shoot");
                Bullet b = Instantiate(bullet, transform.position, new Quaternion());
                b.transform.up = transform.right;
                b.tag = "Bullet";
                Destroy(b.gameObject, 2f);
                nextShot = Time.time + .3f;
                
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "BulletWall")
        {
            animator.SetTrigger("OnHit");
        }
    }
}
