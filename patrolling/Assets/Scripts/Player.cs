using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //controller.SimpleMove(new Vector3(h*15, 0, v*15));
        controller.Move(new Vector3(h * Time.deltaTime * 15, 0, v * Time.deltaTime * 15));
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print("Collision detected");

    }
}
