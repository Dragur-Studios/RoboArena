using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LeaveGameHandler : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(LeaveGame);
    }

    void LeaveGame()
    {
        PhotonNetwork.LeaveRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
