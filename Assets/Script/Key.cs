using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Key : MonoBehaviour
{
    public TextMeshProUGUI alphabet;
    public OverallData overallData;
    public Action<string> keyPress;
    public UnityEngine.UI.Image buttonImage;
    public UnityEngine.UI.Button buttonKey;

    public void Setup(string alphabet,Action<string> keyPress)
    {
        this.keyPress = keyPress;
        this.alphabet.SetText(alphabet); 
    }

    public void KeyPress()
    {
        this.keyPress?.Invoke(alphabet.text);
    }
}
