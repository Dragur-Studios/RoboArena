using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPlayerList : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject playerBadgePrefab;
    List<NetworkPlayerBadge> players = new List<NetworkPlayerBadge>();

    public void AddPlayer(Player player)
    {

        GameObject go = Instantiate(playerBadgePrefab, transform, false);
        var badge = go.GetComponent<NetworkPlayerBadge>();

        badge.SetName(player.NickName);
        
        players.Add(badge);
    }

    private void Update()
    {
        var networkplayers = Matchmaker.GetRoomPlayers();

        ClearPlayerList();
        for (int i = 0; i < networkplayers.Count; i++)
        {
            AddPlayer(networkplayers[i]);
        }
    }

    private void ClearPlayerList()
    {
        for (int i = 0; i < players.Count; i++)
        {
            Destroy(players[i].gameObject);
        }
        players.Clear();
    }
}
