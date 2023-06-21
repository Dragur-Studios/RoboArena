using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraNanager : MonoBehaviourPunCallbacks
{
    List<Camera> cameras = new List<Camera>();



    private void Awake()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        cameras = GetComponentsInChildren<Camera>().ToList();

        cameras.ForEach(cam => cam.gameObject.SetActive(false));
        
        if (PhotonNetwork.IsMasterClient)
        {
            cameras[0].gameObject.SetActive(true);
        }
        else
        {
            cameras[1].gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
