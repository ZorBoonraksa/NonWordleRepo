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

    public void Setup(string alphabet,Action<string> keyPress)
    {
        this.keyPress = keyPress;
        this.alphabet.SetText(alphabet); 
    }//เพิ่มเข้ามา

    public void KeyPress()
    {
        this.keyPress?.Invoke(alphabet.text);
        // GameEvents.current.PressButton(alphabet.text);
        // if(alphabet.text != "del"){
        //     if(overallData.guess.Length < overallData.answer.Length)
        //     {
        //         //overallData.guess += alphabet.text;
        //         overallData.guess += alphabet.text;
        //         if(overallData.guess.Length == overallData.answer.Length)
        //         {
        //             overallData.isEqualLength = true;
        //         }
        //     }
        // }else{
        //     if(overallData.guess.Length > 0)
        //     {
        //         string result = overallData.guess.Remove(overallData.guess.Length - 1);
        //         overallData.guess = result;
        //     }
        // }
    }
}
