using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10.0f;
    float jumpheight = 15.0f;
    float zLimit = 4.8f;
    float xLimit = 4.8f;
    float gravityMod = 3.0f;

    Rigidbody playerRb;   //referencing 

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        //Declare and Initialize variables to reference to User Interaction Inputs
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float jumpInput = Input.GetAxis("Jump");

        //Keybind Controls (GameObject) 
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        if (transform.position.y <= 0.5)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(Vector3.up * jumpheight, ForceMode.Impulse);
            }
        }

        //Setting Boundaries within the plane

        //front and back
        if (transform.position.z < -zLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zLimit);
        }
        else if (transform.position.z > zLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimit);
        }

        //left and right
        if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }



    }

    void MovePlayer()
    {


    }
}
