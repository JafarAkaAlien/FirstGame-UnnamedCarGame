using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADCarMove : MonoBehaviour
{

    public List<Axinfo> teker;
    public float maxMotorTorque = 10;
    public float maxSteerAngle = 30;

    private void FixedUpdate()
    {

        float motor = maxMotorTorque * Input.GetAxis("Vertical");
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
        }
    }
}


    [System.Serializable]
public class Axinfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steer;
}