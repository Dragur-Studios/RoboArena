using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;

public class TestRoomLoader : MonoBehaviourPunCallbacks
{
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("player_arena_2");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }
}
