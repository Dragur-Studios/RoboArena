using UnityEngine;

public class RCMotorTransmitter : MonoBehaviour
{
    public RCMotorReciever reciever;

    private void Update()
    {
        reciever.Trottle = Input.GetAxisRaw("Vertical");
        reciever.Steering = Input.GetAxisRaw("Horizontal");
    }
}
