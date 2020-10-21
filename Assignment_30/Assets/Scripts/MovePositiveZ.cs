using System;
using System.Collections;
using System.Collections.Generic;
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

        if (transform.position.z > 22)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
        }
        
    }
}
