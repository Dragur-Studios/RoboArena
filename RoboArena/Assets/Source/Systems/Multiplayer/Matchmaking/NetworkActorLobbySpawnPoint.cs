using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkActorLobbySpawnPoint : MonoBehaviourPunCallbacks
{
    //Player instance prefab, must be located in the Resources folder
    public GameObject playerPrefab;
    GameObject playerRef;
    
    void Start()
    {

    }
    public override void OnJoinedRoom()
    {
        playerRef = PhotonNetwork.Instantiate($"Prefabs/Networking/{playerPrefab.name}", transform.position, transform.rotation, 0);
    }

    public override void OnLeftLobby()
    {
        Destroy(playerRef);
    }


    void OnGUI()
    {

    }
}
