using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AxelInformation
{
    public List<WheelCollider> wheels;
    public bool isMotor;
    public bool isSteering;
    public bool isBrake;
}
