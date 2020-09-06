using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject projectile;
    public Transform shootPosition;
    private RaycastHit hit;
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, .5f, hit.point.z));
        }

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(horizontal * Time.deltaTime * 5, 0, vertical * Time.deltaTime * 5, Space.World);
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(projectile, shootPosition.position, shootPosition.rotation);
            yield return new WaitForSeconds(1f);
        }
    }
}
