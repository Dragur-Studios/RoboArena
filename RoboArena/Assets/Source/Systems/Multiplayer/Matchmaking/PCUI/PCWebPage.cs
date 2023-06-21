using UnityEngine;

public class PCWebPage : MonoBehaviour
{
    public string url;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide() 
    {
        gameObject.SetActive(false);
    }
}
