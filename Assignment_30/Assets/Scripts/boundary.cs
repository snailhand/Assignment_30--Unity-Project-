using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class boundary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerExit(Collider other)
    {
            if (other.gameObject.CompareTag("Player"))
            {
            Destroy(other.gameObject);
            }       
    }

}
