using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnsField : MonoBehaviour
{
    public TextMeshProUGUI ansLetter;

    void Awake() 
    {
        ansLetter.text = "";    
    }

    public void GetLetter(string letter)
    {
        ansLetter.text = letter;
    }
}
