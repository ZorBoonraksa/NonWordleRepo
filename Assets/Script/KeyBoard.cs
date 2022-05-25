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
    private static Dictionary<string,Key> keyMapping = new Dictionary<string, Key>();
    void Awake() 
    {
        
        for(int index = 0;index < buttons.Length;index++)
        {
            for(int cursor = 0;cursor < buttons[index].keyButton.Count;cursor++)
            {   
                buttons[index].keyButton[cursor].Setup(keyBlinds[index].key[cursor],(key) => buttonPress?.Invoke(key));
                keyMapping.Add(keyBlinds[index].key[cursor],buttons[index].keyButton[cursor]);
            }
        }
    }

    public void ResetInteractable()
    {
        for(int index = 0;index < buttons.Length;index++)
        {
            for(int cursor = 0;cursor < buttons[index].keyButton.Count;cursor++)
            {   
                buttons[index].keyButton[cursor].buttonImage.color = new Color(0.9528302f,0.9384479f,0.9384479f,1);
                buttons[index].keyButton[cursor].buttonKey.interactable = true;
            }
        }
    }

    public void OnInput(string key,CheckingState result)
    {
        switch (result)
        {
            case CheckingState.Correct:
                keyMapping[key].buttonImage.color = new Color(0.6745098f,0.8392157f,0.2117647f,1);
                break;
            case CheckingState.WrongIndex:
                keyMapping[key].buttonImage.color = new Color(0,0,1,1);
                break;
            case CheckingState.Wrong:
                keyMapping[key].buttonKey.interactable = false;
                keyMapping[key].buttonImage.color = new Color(0.6037736f,0.5718761f,0.5718761f,1);
                break;
        }
    }
}
