using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovePositiveZ : MonoBehaviour
{
    float forwardSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //make it move forward
        if (transform.position.z > 22)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
        }

        //make it rotate
        transform.Rotate(Vector3.forward, forwardSpeed * Time.deltaTime * 10);
    }
}
