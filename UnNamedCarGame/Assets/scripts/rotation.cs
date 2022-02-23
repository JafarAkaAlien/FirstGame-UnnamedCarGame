using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    // Start is called before the first frame update
    float tiltAngle=-2;
    
    public GameObject car;


    // Update is called once per frame
    void Update()
    {

        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
       
            transform.Rotate(Vector3.forward * tiltAroundZ);
        
         
        
    }
}
