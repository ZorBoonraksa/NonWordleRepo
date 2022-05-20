using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class keyBlind
{
    public List<string> key = new List<string>();
}

[System.Serializable]
public class buttons
{
    public List<Key> keyButton = new List<Key>();
}

public class KeyBoard : MonoBehaviour
{
    public keyBlind[] keyBlinds;
    public buttons[] buttons;
    public UnityEngine.Events.UnityEvent<string> buttonPress;
    void Awake() 
    {
        
        for(int index = 0;index < buttons.Length;index++)
        {
            for(int cursor = 0;cursor < buttons[index].keyButton.Count;cursor++)
            {   
                buttons[index].keyButton[cursor].Setup(keyBlinds[index].key[cursor],(key) => buttonPress?.Invoke(key));
            }
        }
    }
}
