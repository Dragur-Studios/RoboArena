using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(RCMotorReciever))]
public class RCMotor : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] float maxTorque = 500.0f;
    [SerializeField] float maxTurnRadius = 30.0f;
    [SerializeField] float maxBrakeForce = 99999.99f;

    [Header("Axels")]
    [SerializeField] List<AxelInformation> axels = new List<AxelInformation>();

    [Header("State")]
    [SerializeField, ReadOnly] bool isPowerdOn = false;


    RCMotorReciever reciever;
    private void Start()
    {
        reciever = GetComponent<RCMotorReciever>();
    }

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
        visualWheel.transform.Rotate(0, 0, 90);
    
    }

    internal void PowerOn()
    {
        isPowerdOn = true;
    }

    private void Update()
    {
        if (!isPowerdOn)
            return;

        foreach (var axel in axels)
        {
            if (axel.isSteering)
            {
                for (int i = 0; i < axel.wheels.Count; i++)
                {
                    axel.wheels[i].steerAngle = reciever.Steering * maxTurnRadius;
                }
            }

            if (axel.isMotor)
            {
                for (int i = 0; i < axel.wheels.Count; i++)
                {
                    axel.wheels[i].motorTorque = reciever.Trottle * maxTorque;
                }
            }

            if (axel.isBrake)
            {
                for (int i = 0; i < axel.wheels.Count; i++)
                {
                    float brakeTorque = 0.0f;

                    // just apply the brakes when the throttle is not being pressed
                    if(Mathf.Abs(reciever.Trottle) <= 0.1f)
                    {
                        brakeTorque = maxBrakeForce;
                    }

                    axel.wheels[i].brakeTorque = brakeTorque;
                }
            }

            for (int i = 0; i < axel.wheels.Count; i++)
            {

                ApplyLocalPositionToVisuals(axel.wheels[i]);
                ApplyLocalPositionToVisuals(axel.wheels[i]);
            }

        };
    }

}
