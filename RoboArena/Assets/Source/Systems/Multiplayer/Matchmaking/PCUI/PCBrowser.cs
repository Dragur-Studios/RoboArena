using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class PCBrowser : MonoBehaviour
{
    List<iWebPageListener> listeners = new List<iWebPageListener>();
    Stack<string> forward_history = new Stack<string>();
    Stack<string> back_history = new Stack<string>();
    Action<string> OnWebpageChanged;

    string Current { get => back_history.Peek(); }

    public bool isOpen { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        OnWebpageChanged = HandleWebsiteChanged;
        
    }


    public void Open()
    {
        if (isOpen)
            return;

        isOpen = true;

        gameObject.SetActive(isOpen);
    } 
    public void Close()
    {
        gameObject.SetActive(false);
        isOpen = false;
        
        FindObjectOfType<InteractionHandler>().isInteracting = false;
    }

    public void OpenPage(string url)
    {
        if (url == "\\" || url == "/")
            return;

        forward_history.Clear();

        back_history.Push(url);

        OnWebpageChanged?.Invoke(Current);

    }

    public void HandleWebsiteChanged(string url)
    {
        listeners.ForEach(listener => {
            listener.OnWebPageChanged(url);
        });
    }

    public void Back()
    {
        var temp = back_history.Peek();
        back_history.Pop();
        forward_history.Push(temp);

        OnWebpageChanged?.Invoke(Current);
    }

    public void Forward()
    {
        var temp = forward_history.Peek();
        forward_history.Pop();
        back_history.Push(temp);

        OnWebpageChanged?.Invoke(Current);

    }

    public void ClearHistory()
    {
        back_history.Clear();
        forward_history.Clear();
    }

    public static void AddListener(iWebPageListener pCBrowserUrl)
    {
        instance.listeners.Add(pCBrowserUrl);
    }

    static PCBrowser instance = null;
}
