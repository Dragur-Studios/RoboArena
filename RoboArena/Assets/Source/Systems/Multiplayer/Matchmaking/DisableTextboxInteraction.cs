using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTextboxInteraction : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TMPro.TMP_InputField>().interactable = false;
    }
}
