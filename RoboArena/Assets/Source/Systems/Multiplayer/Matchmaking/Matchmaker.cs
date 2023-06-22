using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.ComponentModel;

public class Matchmaker : MonoBehaviourPunCallbacks
{
    const string BATTLENET = "https://www.battlenetwork.com";

    // temporary
    [ReadOnly, SerializeField] string gameVersion = "0.1.0c";
    [ReadOnly, SerializeField] string localPlayerUsername = "Player";

    [SerializeField] PCUIManager pcUI;

    public bool isConnecting { get; private set; }

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        instance = this;
        pcUI.CloseBrowser();

        localPlayerUsername = $"Player#{Guid.NewGuid().ToString().Substring(4, 8)}";
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"Failed to Connect to Photon status-code: <color=red>{cause}</color> serverAddress: {PhotonNetwork.ServerAddress}");
        isConnecting = false;
        pcUI.CloseBrowser();
    }

    public override void OnConnectedToMaster()
    {
        //matchmaker_ui.SetActive(true);
        pcUI.OpenBrowser();

        PhotonNetwork.NickName = localPlayerUsername;

        PhotonNetwork.JoinLobby(TypedLobby.Default);

        isConnecting = false;

    }


    public override void OnJoinedLobby()
    {
        Debug.Log("<color=green>Opening BattleNetwork</color>");
        pcUI.OpenPage(BATTLENET);
    }

    public override void OnLeftLobby()
    {
        pcUI.CloseBrowser();
    }

    public override void OnJoinedRoom()
    {
        string arenaList = BATTLENET + "/arena_list";
        pcUI.OpenPage(arenaList);
    }

    public override void OnLeftRoom()
    {
        pcUI.OpenPage(BATTLENET);
    }

    public override void OnPlayerEnteredRoom(Player other)
    {
        if (!PhotonNetwork.IsMasterClient)
            return;

        int player_count = PhotonNetwork.CurrentRoom.PlayerCount;
        int required_players_for_match = PhotonNetwork.CurrentRoom.MaxPlayers;

        if (player_count >= required_players_for_match)
        {
            switch (player_count)
            {
                case 2:
                    PhotonNetwork.LoadLevel("player_arena_2");
                    break;

                case 4:
                    PhotonNetwork.LoadLevel("player_arena_4");
                    break;

            }
        }

    }

    public static void Disconnect()
    {
        PhotonNetwork.LeaveLobby();
    }

    public static void Connect()
    {
        instance.pcUI.OpenBrowser();

        if (!PhotonNetwork.IsConnected)
        {
            // setup connection settings
            PhotonNetwork.PhotonServerSettings.AppSettings.AppVersion = instance.gameVersion;

            instance.isConnecting = PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            PhotonNetwork.JoinLobby();
        }
    }

    internal static List<Player> GetRoomPlayers()
    {
        List<Player> list = new List<Player>();

        foreach (var kvp in PhotonNetwork.CurrentRoom.Players)
        {
            list.Add(kvp.Value);
        }
        return list;
    }

    static Matchmaker instance;


}
