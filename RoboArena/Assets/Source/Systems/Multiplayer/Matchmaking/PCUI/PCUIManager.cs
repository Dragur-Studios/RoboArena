using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCUIManager : MonoBehaviour
{
    [SerializeField] PCBrowser browser;

    private void Awake()
    {
        browser.Close();
    }

    public void OpenPage(string url)
    {
        browser.OpenPage($"{url}");
    }

    public void OpenBrowser(string url="")
    {
        if (browser.isOpen)
            return;

        browser.Open();
        browser.OpenPage($"{url}");
    }

    public void CloseBrowser()
    {
        browser.ClearHistory();
        browser.Close();
    }
}
