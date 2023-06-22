using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LogOutHandler : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    void Start()
    {
        button.onClick.AddListener(LogOut);
    }

    
    void LogOut()
    {
        EventSystem.current.SetSelectedGameObject(null);
        Matchmaker.Disconnect();      
    }
}
