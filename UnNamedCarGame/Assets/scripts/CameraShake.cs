using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject adc;
    public Camera cam;
    public Transform target;
    public Vector3 offset;
    float carspeed=0;
    float normal_pos;
    public float mag=0.02f;
    Vector3 origpos; // original position of camera
    private void Start()
    {
        
        origpos = transform.position;
        normal_pos = cam.fieldOfView;
    }
    void Update()
    {
        Vector3 back = -target.position;
        back.y = 0.1f;
        transform.position = target.position;
        transform.forward = target.forward;
        carspeed = adc.GetComponent<ADCarMove>().speed;
        cam.fieldOfView = normal_pos + carspeed/2;
        if (carspeed > 15)
        {
            
            float vuruq = (carspeed*2)/10000;
            float x = Random.Range(-1f, 1f) * vuruq;
            float y = Random.Range(-1f, 1f) * vuruq;
            transform.position += new Vector3(x, y, 0);
        }
        else if (carspeed > 25)
        {
            
            float vuruq = (carspeed * 5) / 10000;
            float x = Random.Range(-1f, 1f) * vuruq;
            float y = Random.Range(-1f, 1f) * vuruq;
            transform.position += new Vector3(x, y, 0);
        }
        //else transform.position = origpos;
    }
}
