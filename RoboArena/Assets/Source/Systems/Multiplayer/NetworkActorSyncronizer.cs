using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkActorSyncronizer : MonoBehaviourPunCallbacks, IPunObservable
{
    public MonoBehaviour[] localScripts;
    public GameObject[] localObjects;
    
    Vector3 latestPosition;
    Quaternion latestRotation;

    void Start()
    {
        if (photonView.IsMine)
        {
            // player is local
        }
        else
        {
            for (int i = 0; i < localScripts.Length; i++)
            {
                localScripts[i].enabled = false;
            }
            for (int i = 0; i < localObjects.Length; i++)
            {
                localObjects[i].SetActive(false);
            }
        }
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            transform.position = Vector3.Lerp(transform.position, latestPosition, Time.deltaTime * 10.0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, latestRotation, Time.deltaTime * 10.0f);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            latestPosition = (Vector3)stream.ReceiveNext();
            latestRotation = (Quaternion)stream.ReceiveNext();
        }
    }

}
