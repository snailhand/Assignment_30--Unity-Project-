using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController29 : MonoBehaviour
{
    //Global Variables:

    float speed = 14.0f;
    float jumpheight = 15.0f;
    float zLimit = 30f;
    float xLimit = 4.5f;
    float gravityMod = 3.0f;
    bool isOnGround = true;
    bool ridingCube = false;
    float jumpCount = 0;

    //referencing 
    Rigidbody playerRb;   
    public GameObject MoveCube;
    
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody link

        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        //Declare and Initialize variables to reference to User Interaction Inputs
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        //Keybind Controls (GameObject) 
        transform.Translate(Vector3.forward * Time.deltaTime * horizontalInput * speed);
        transform.Translate(Vector3.left * Time.deltaTime * verticalInput * speed);

        PlayerJump();
      

        //Setting Boundaries within the plane

        //front and back
        if (transform.position.z < -9)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -9);
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

    //Method Call from UnityEngine (Triggers when Object collides with ground)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpCount = 0;
        }
        if (collision.gameObject.CompareTag("MoveCube"))
        {
            ridingCube = true;
            jumpCount = 0;
        }
    }

    void PlayerJump()
    {
        if (isOnGround || ridingCube && jumpCount == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("Player JUMPING Y Position: " + transform.position.y);
                playerRb.AddForce(Vector3.up * jumpheight, ForceMode.Impulse);
                isOnGround = false;
                jumpCount += 1;

            }

        }
    }
    
}
