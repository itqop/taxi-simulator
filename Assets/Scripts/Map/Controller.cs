using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}
public class Controller : MonoBehaviour
{
    public List<AxleInfo> axleInfos; 
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float breakForce;
    public float motor2;
    public float steering2;
    public float steering;
    private Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0) {
            return;
        }
     
        Transform visualWheel = collider.transform.GetChild(0);
     
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
     
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
    
    private void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void FixedUpdate()
    {
        steering = Mathf.Clamp(Input.GetAxis("Horizontal"), -1, 1);
        motor2 = maxMotorTorque * Input.GetAxis("Vertical");
        steering2 = maxSteeringAngle * steering;

        if (Input.GetButton("Jump"))
        {
            ApplyBreaking();
        }
        else
        {
            DisableBreaking();
        }
        
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering2;
                axleInfo.rightWheel.steerAngle = steering2;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor2;
                axleInfo.rightWheel.motorTorque = motor2;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        } 
        
        
    }
    private void ApplyBreaking()
    {
        m_Rigidbody.drag = 1;
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.brakeTorque = breakForce;
                axleInfo.rightWheel.brakeTorque = breakForce;
                axleInfo.leftWheel.motorTorque = 0;
                axleInfo.rightWheel.motorTorque = 0;
            }
        }
     
    }
    private void DisableBreaking()
    {
        m_Rigidbody.drag = 0;
        foreach (AxleInfo axleInfo in axleInfos)
        {
            axleInfo.leftWheel.brakeTorque = 0;
            axleInfo.rightWheel.brakeTorque = 0;
        }
     
    }
}

