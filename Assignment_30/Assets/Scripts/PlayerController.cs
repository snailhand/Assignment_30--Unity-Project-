using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    float speed = 10.0f;
    float jumpheight = 15.0f;
    float djumpheight = 15.0f;
    float zLimit = 6.5f;
    float xLimit = 6.5f;
    float gravityMod = 3.0f;
    bool isOnGround = true;
    float jumptimes = 0f;
    float jumpcount = 0f;

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


        PlayerJump();
        

        //Setting Boundaries within the plane
        /*
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
        */
    }

    //Method Call from UnityEngine (Triggers when Object collides with ground)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpcount = 0;
        }

    }

    //Player Jumping Method
    void PlayerJump()
    {
        if (isOnGround)
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpcount == 0)
            {
                //Debug.Log("Player JUMPING Y Position: " + transform.position.y);
                playerRb.AddForce(Vector3.up * jumpheight, ForceMode.Impulse);
                isOnGround = false;
                jumptimes += 1;
                Debug.Log("Successful Jumps: " + jumptimes);

                //doublejump
                jumpcount += 1;
            }

        }
        
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpcount == 1)
            {
                playerRb.AddForce(Vector3.up * djumpheight, ForceMode.Impulse);
                jumpcount += 1;
            }
        }
        
    }
}
