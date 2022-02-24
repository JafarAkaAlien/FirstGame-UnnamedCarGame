using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSc : MonoBehaviour
{

   public GameObject door1;
   public GameObject door2;
    bool toggle;
    bool iscolesed = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("v") && !toggle && iscolesed)
        {
            toggle = true;
        }
        else if(Input.GetKeyDown("v") && toggle && iscolesed)
        {
            toggle = false;
        }
        
        if (door1.transform.position.y >= 69 || door1.transform.position.y<=24)
        {
            iscolesed = true;
        }
        else
        {
            iscolesed = false;
        }
        if (door1.transform.position.y < 70 && toggle)
        {
            door1.transform.position = door1.transform.position + 6*Time.deltaTime*new Vector3(0,1,0);
            door2.transform.position = door2.transform.position - 6 * Time.deltaTime * new Vector3(0, 1, 0);
        }
        

        else if(door1.transform.position.y>22 && !toggle)
        {
            door1.transform.position = door1.transform.position - 6 * Time.deltaTime * new Vector3(0, 1, 0);
            door2.transform.position = door2.transform.position + 6 * Time.deltaTime * new Vector3(0, 1, 0);
        }
       
    }
}
