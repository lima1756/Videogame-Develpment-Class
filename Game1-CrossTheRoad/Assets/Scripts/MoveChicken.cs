using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveChicken : MonoBehaviour
{

    public float speed = 10f;
    public Text textPoints;
    private static int myPoints;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        myPoints = 0;
        updateText();
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * Time.deltaTime;

        transform.Translate(speed * horizontalMovement, 0, speed * verticalMovement, Space.Self);
    }

    public static void changePoints(int points)
    {
        myPoints += points;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Barn")
        {
            this.transform.position = startPos;
            myPoints += 75;
        }
        else if (other.tag == "Respawn") {
            this.transform.position = startPos;
            myPoints -= 10;
        }
        updateText();
    }

    private void OnTriggerStay(Collider other)
    {
        updateText();
    }

    private void updateText() {
        textPoints.text = "Points: " + myPoints;
    }
}
