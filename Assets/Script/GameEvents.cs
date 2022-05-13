using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    void Awake() 
    {
        current = this;
    }

    public event Action onButtonPress;
    public void PressButton()
    {
        if(onButtonPress != null)
        {
            onButtonPress();
        }
    }
}
