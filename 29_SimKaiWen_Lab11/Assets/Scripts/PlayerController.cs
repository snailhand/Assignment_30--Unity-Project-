using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 15;
    float jumpHeight = 15;
    float health = 3;

    Animator Animator;
    public GameObject ModelCube;
    public Rigidbody PlayerRb;
    bool onGround;
    bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        Animator = ModelCube.GetComponent<Animator>();
        Physics.gravity *= 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive == true)
        {
            //Forward Moving

            if (Input.GetKeyDown(KeyCode.W))
            {
                Animator.SetTrigger("isMoving");
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                Animator.SetBool("moving", true);
            }


            if (Input.GetKeyUp(KeyCode.W))
            {
                Animator.SetBool("moving", false);
            }

            //Left Moving

            if (Input.GetKeyDown(KeyCode.A))
            {
                Animator.SetTrigger("isMoving");
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 270, 0);
                Animator.SetBool("moving", true);
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                Animator.SetBool("moving", false);
            }

            //Backward Moving

            if (Input.GetKeyDown(KeyCode.S))
            {
                Animator.SetTrigger("isMoving");
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                Animator.SetBool("moving", true);
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                Animator.SetBool("moving", false);
            }

            //Right Moving

            if (Input.GetKeyDown(KeyCode.D))
            {
                Animator.SetTrigger("isMoving");
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                Animator.SetBool("moving", true);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                Animator.SetBool("moving", false);
            }

            PlayerJump();
        }
        // DIE

        if(Input.GetKeyDown(KeyCode.K))
        {
            health -= 1;
            if (health <= 0)
            {
                Animator.SetTrigger("death");
                alive = false;
            }
        }
        
        
    }

    private void PlayerJump()
    {
        if (onGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerRb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                Animator.SetTrigger("jump");
                onGround = false;
                Animator.SetBool("landed", false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
            Animator.SetBool("landed", true);
        }
    }
}
