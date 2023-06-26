using UnityEngine;

public class Battery : MonoBehaviour
{
    public float Charge { get; private set; }

    private void OnEnable()
    {
        Charge = 1.0f;
    }

    private void Update()
    {
        
    }

}
