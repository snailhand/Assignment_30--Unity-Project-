using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    float jumpheight = 20f;
    bool isOnGround;
    float gravityMod = 5f;
    float zLimit = 19f;
    float xLimit = 19f;
    float speed = 20.0f;

    Rigidbody playerRb;
    Renderer playerRen;

    public Material[] playerMat;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityMod;
        playerRb = GetComponent<Rigidbody>();
        playerRen = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Declare and Initialize variables to reference to User Interaction Inputs
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        //Keybind Controls (GameObject) 
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        //Setting Boundaries within the plane

        //front and back
        if (transform.position.z < -zLimit)
        {
            playerRen.material.color = playerMat[1].color;
            transform.position = new Vector3(transform.position.x, transform.position.y, -zLimit);
        }
        else if (transform.position.z > zLimit)
        {
            playerRen.material.color = playerMat[3].color;
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimit);
        }


        //left and right
        if (transform.position.x < -xLimit)
        {
            playerRen.material.color = playerMat[4].color;
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xLimit)
        {
            playerRen.material.color = playerMat[5].color;
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
        


        if (isOnGround)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("Player JUMPING Y Position: " + transform.position.y);
                playerRb.AddForce(Vector3.up * jumpheight, ForceMode.Impulse);
                playerRen.material.color = playerMat[0].color;
                isOnGround = false;

            }

        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            isOnGround = true;
           // playerRen.material.color = Color.white;
        }

    }
}
