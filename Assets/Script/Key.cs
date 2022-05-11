using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    public TextMeshProUGUI alphabet;

    public string KeyPress()
    {
        return alphabet.text;
    }
}
