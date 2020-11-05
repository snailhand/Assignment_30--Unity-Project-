using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControlScript : MonoBehaviour
{
    public GameObject upCube;
    public GameObject downCube;
    public GameObject leftCube;
    public GameObject rightCube;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Up Key Controls

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            upCube.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
            print("Up Arrow pressed.");
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            upCube.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
            print("Up Arrow released.");
        }

        //Down Key Controls

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            downCube.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
            print("Down Arrow pressed.");
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            downCube.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
            print("Down Arrow released.");
        }

        //Left Key Controls

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            leftCube.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
            print("Left Arrow pressed.");
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            leftCube.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
            print("Left Arrow released.");
        }

        //Right Key Controls

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            rightCube.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
            print("Right Arrow pressed.");
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            rightCube.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
            print("Right Arrow released.");
        }
    }
}
