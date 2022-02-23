using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Drivetrain))]
public class ADCarMove : MonoBehaviour
{
  
    public Rigidbody car;

    public float speed;

    public List<Axinfo> teker;
    public float maxMotorTorque = 10;
    public float maxSteerAngle = 30;



    private void Start()
    {
        speed = car.velocity.magnitude;
    }



    private void FixedUpdate()
    {
        /// motor:
        float brok=30000;
        bool brake = false;
        speed = car.velocity.z;
        float qaz = Input.GetAxis("Vertical");
        float don = Input.GetAxis("Horizontal");
        float currentTorque = maxMotorTorque;

        //if (Input.GetKeyDown("space"))
        //{
        //    brake = true;
        //}
        //else if (Input.GetKeyUp("space"))
        //{
        //    brake = false;
        //}
        brake = Input.GetKey("space");
        





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