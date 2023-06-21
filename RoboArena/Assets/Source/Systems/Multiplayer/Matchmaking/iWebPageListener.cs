using UnityEngine;

public abstract class iWebPageListener :MonoBehaviour
{
    public abstract void OnWebPageChanged(string newURL);
}
