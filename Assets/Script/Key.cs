using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    public TextMeshProUGUI alphabet;
    public OverallData overallData;

    public void KeyPress()
    {
        if(overallData.guess.Length < overallData.answer.Length)
        {
            overallData.guess += alphabet.text;
            overallData.currentGuess = alphabet.text;
            if(overallData.guess.Length == overallData.answer.Length)
            {
                overallData.isEqualLength = true;
            }
        }else{
            return;
        }
    }

    public void DeleteKey()
    {
        Debug.Log("Delete");
    } 
}
