using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

public class MatchButton : MonoBehaviourPunCallbacks
{
    [SerializeField] MatchType type;
    
    Button button;
    
    public enum MatchType
    {
        Solo_2P,
        Solo_4P,

    }

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        ButtonClickedEvent cb = new ButtonClickedEvent();
        cb.AddListener(FindMatch);
        button.onClick = cb;
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        switch (type)
        {
            case MatchType.Solo_2P:
                {
                    CreateRoom(2);
                }
                break;
            case MatchType.Solo_4P:
                {
                    CreateRoom(4);
                }
                break;
        }
    }

    void FindMatch()
    {
        switch (type)
        {
            case MatchType.Solo_2P:
                {
                    JoinOrCreateRoom(2);
                }
                break;
            case MatchType.Solo_4P:
                {
                    JoinOrCreateRoom(4);
                }
                break;
        }
    }

    private void JoinOrCreateRoom(int requiredRoomSize)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)requiredRoomSize;

        TypedLobby typedLobby = new TypedLobby("CustomLobby", LobbyType.Default);

        PhotonNetwork.JoinOrCreateRoom(typedLobby.Name, roomOptions, typedLobby);
    }

    private void CreateRoom(int requiredRoomSize)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = requiredRoomSize; 

        TypedLobby typedLobby = new TypedLobby("CustomLobby", LobbyType.Default);

        PhotonNetwork.CreateRoom(null, roomOptions, typedLobby);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
