using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NetworkPlayerBadge : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;

    internal void SetName(string name)
    {
        nameText.text = name;
    }


}
