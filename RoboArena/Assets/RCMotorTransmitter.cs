using UnityEngine;
using Photon.Pun;
public class RCMotorTransmitter : MonoBehaviourPunCallbacks
{
    /*public */RCMotorReciever reciever;

    private void Awake()
    {
        reciever = GetComponent<RCMotorReciever>();
    }

    private void Update()
    {
        if (!photonView.IsMine)
            return;

        reciever.Trottle = Input.GetAxisRaw("Vertical");
        reciever.Steering = Input.GetAxisRaw("Horizontal");
    }
}
