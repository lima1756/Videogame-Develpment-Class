using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public string tankPlayer;
    public GameObject cannon;
    public Transform bulletPosition;
    public GameObject bullet;
    private float lastFire;

    // Start is called before the first frame update
    void Start()
    {
        lastFire = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal_" + tankPlayer);
        float vertical = Input.GetAxis("Vertical_" + tankPlayer);
        float cannonMovement = -Input.GetAxis("Cannon_" + tankPlayer);
        float fire = Input.GetAxis("Fire_" + tankPlayer);
        transform.Translate(0, 0, vertical * Time.deltaTime * 2.5f);
        transform.Rotate(Vector3.up, horizontal * Time.deltaTime* 75f);
        float rotationAct = cannon.transform.rotation.eulerAngles.x;
        if(cannon.transform.rotation.eulerAngles.x > 180)
        {
            rotationAct = -(360 - rotationAct);
        }
        if (rotationAct < 30 && cannonMovement>0 || rotationAct > -20 && cannonMovement < 0)
        {
            
            cannon.transform.Rotate(Vector3.right, cannonMovement * Time.deltaTime * 25f);
            print(cannon.transform.rotation.eulerAngles.x);
        }

        if(fire==1 && lastFire == 0)
        {
            GameObject go = Instantiate(bullet, bulletPosition.position, bulletPosition.rotation, this.transform);
        }
        lastFire = fire;
    }
}
