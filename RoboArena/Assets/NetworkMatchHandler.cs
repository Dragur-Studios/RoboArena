using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkMatchHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if(!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("player_workshop");
            return;
        }

        // Get the Room Players.
        var players = PhotonNetwork.CurrentRoom.Players;


        GameObject bot = PhotonNetwork.Instantiate("Prefabs/TestBot", Vector3.zero, Quaternion.identity);
        bot.GetComponent<RCMotor>().PowerOn();

        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
