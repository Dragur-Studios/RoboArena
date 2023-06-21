using TMPro;
using UnityEngine;

public class PCBrowserUrl : iWebPageListener
{
    private void Start()
    {
        PCBrowser.AddListener(this);
    }

    [SerializeField] TMP_Text urlText;
    [SerializeField, ReadOnly] string url;

    public override void OnWebPageChanged(string newURL)
    {
        url = newURL;
    }

    private void Update()
    {
        if (urlText == null)
            return;

        urlText.text = url;
    }

}
