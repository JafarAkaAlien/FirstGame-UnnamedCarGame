using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Drivetrain))]
public class ADCarMove : MonoBehaviour
{
  
    public Rigidbody car;

    public float speed;

    public List<Axinfo> teker;
    public float maxMotorTorque = 800;
    public float maxSteerAngle = 28;



    private void Start()
    {
        speed = car.velocity.magnitude;
    }
    private float rotation;


    private void FixedUpdate()
    {
        rotation = Mathf.Clamp(rotation, -90, 90);
        var rot = transform.localEulerAngles;
        rot.z = rotation;
        transform.localEulerAngles = rot;
        /// motor:
        float brok=30000;
        bool brake = false;
        speed = car.velocity.magnitude;
        float qaz = Input.GetAxis("Vertical");
        float don = Input.GetAxis("Horizontal");
        

        //if (Input.GetKeyDown("space"))
        //{
        //    brake = true;
        //}
        //else if (Input.GetKeyUp("space"))
        //{
        //    brake = false;
        //}
        brake = Input.GetKey("space");

        if (speed > 15)
        {
            maxSteerAngle = 20;
        }
        if (speed > 20)
        {
            maxSteerAngle = 15;
        }
        else if (speed > 40)
        {
            maxSteerAngle = 10;
        }
        else
        {
            maxSteerAngle = 30;
        }

        if (speed > 30)
        {
            maxMotorTorque = 100;
        }
        else
        {
            maxMotorTorque = 900;
        }
        float currentTorque = maxMotorTorque;



        float motor = currentTorque * qaz;
        float steer = maxSteerAngle * Input.GetAxis("Horizontal");

        foreach (Axinfo t in teker)
        {
            if (t.motor)
            {
                t.leftWheel.motorTorque = motor;
                t.rightWheel.motorTorque = motor;
            }
            if (t.steer)
            {
                t.leftWheel.steerAngle = steer;
                t.rightWheel.steerAngle = steer;
            }
            if (t.brik && brake)
            {
                t.leftWheel.brakeTorque = brok ;
                t.rightWheel.brakeTorque = brok;
            }
            else
            {
                t.rightWheel.brakeTorque = 0;
                t.leftWheel.brakeTorque = 0;
            }
            
            ApplyRotation(t.leftWheel, t.leftReal.transform);
            ApplyRotation(t.rightWheel, t.rightReal.transform);
        }
    }
    public void ApplyRotation(WheelCollider wheel, Transform visualWheel)

    {

        Vector3 position;
        Quaternion rotation;
        wheel.GetWorldPose(out position, out rotation);
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }


}


    [System.Serializable]
public class Axinfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public GameObject leftReal;
    public GameObject rightReal;
    public bool motor;
    public bool steer;
    public bool brik;
}