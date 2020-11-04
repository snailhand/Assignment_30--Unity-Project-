using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositiveZ : MonoBehaviour
{

    public float speed = 6.0f;
    public float cubezLimit = 26.0f;
    float startPos;
    public bool forwardMove = true;
    bool ridingCube = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovingCube();

    }

    public void MovingCube()
    {
        //moving cube

        if (transform.position.z < cubezLimit && forwardMove)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (!forwardMove)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);

        }

        //checking direction 

        if (transform.position.z <= startPos)
        {
            forwardMove = true;
        }
        if (transform.position.z >= cubezLimit)
        {
            forwardMove = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            ridingCube = true;
            collision.collider.transform.SetParent(transform);

        }
       
    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            ridingCube = false;
            collision.collider.transform.SetParent(null);

        }

    }

}
