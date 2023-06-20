using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // temporary
    [ReadOnly, SerializeField] string gameVersion = "0.1.0c";
    
    [Header("Hints")]
    [ReadOnly, SerializeField] string localPlayerUsername = "Player1";
    [ReadOnly, SerializeField] string roomName = "Room 1";
    Vector2 roomListScroll = Vector2.zero;
    bool joiningRoom = false;

    List<RoomInfo> availableRooms = new List<RoomInfo>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        availableRooms = roomList;
    }

    private void Awake()
    {

    }

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        if (!PhotonNetwork.IsConnected)
        {
            // setup connection settings
            PhotonNetwork.PhotonServerSettings.AppSettings.AppVersion = gameVersion;
            
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"Failed to Connect to Photon status-code: <color=red>{cause}</color> serverAddress: {PhotonNetwork.ServerAddress}");
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        bool isPlayerAuthenticated = true;
        
        if(isPlayerAuthenticated) {
            PhotonNetwork.LoadLevel("multiplayer_lobby");
        }
        else
        {
            PhotonNetwork.LoadLevel("multiplayer_authentication");
        }
    }

    public override void OnLeftLobby()
    {
        
    }




}
