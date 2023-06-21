using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCWebPageDocumentView : iWebPageListener
{
    [Header("__LOAD_ME__")]
    [SerializeField] PCWebPage[] pagePrefabs = new PCWebPage[] { };
    [SerializeField] PCWebPage[] errorPagePrefabs = new PCWebPage[] { };

    List<PCWebPage> network = new List<PCWebPage>();

    public override void OnWebPageChanged(string url)
    {
        network.ForEach(page => {
            if (page.url == url)
                page.Show();
            else
                page.Hide();
        });
        
    }

    void Awake()
    {
        BuildNetwork();
    }

    private void Start()
    {
        PCBrowser.AddListener(this);
    }



    void BuildNetwork()
    {
        for (int i = 0; i < pagePrefabs.Length; i++)
        {
            // create the prefab. 
            // add the instantiated gameobject ref to the network. 
            var page = Instantiate(pagePrefabs[i], transform, false);
            page.Hide();
            network.Add(page);
        }

        for (int i = 0; i < errorPagePrefabs.Length; i++)
        {
            var page = Instantiate(errorPagePrefabs[i], transform, false);
            page.Hide();
            network.Add(page);
        }
    }

}
