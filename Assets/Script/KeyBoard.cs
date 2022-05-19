using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class keyBlind
{
    public List<string> key = new List<string>();
}

public class KeyBoard : MonoBehaviour
{
    public keyBlind[] keyBlinds;
    Key A;
    void Awake() 
    {
        Debug.Log(keyBlinds[0].key[3]);
        // for(int index = 0;index < keyBlind.Length;index++)
        // {
        //     A.Setup(".", (a) => GameEvents.current.PressButton(a));
        // }
    }

}
