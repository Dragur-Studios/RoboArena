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
                    PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
                }
                break;
            case MatchType.Solo_4P:
                {
                    PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, TypedLobby.Default);
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
                    PhotonNetwork.JoinRandomRoom(null, 2);
                }
                break;
            case MatchType.Solo_4P:
                {
                    PhotonNetwork.JoinRandomRoom(null, 4);
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
