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
        speed = car.velocity.magnitude;
        float qaz = Input.GetAxis("Vertical");
        float don = Input.GetAxis("Horizontal");
        float currentTorque = maxMotorTorque;

        if ((speed>0 && qaz<0) || (speed < 0 && qaz > 0))
        {
            currentTorque = maxMotorTorque * 10;
        }





        float motor = currentTorque * Input.GetAxis("Vertical");
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
}