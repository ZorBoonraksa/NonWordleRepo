using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoard : MonoBehaviour
{
    private List<List<string>> keyBlind;

    Key A;
    private void Start() {
        for(int index = 0;index < keyBlind.Count;index++)
        {
            A.Setup(".", (a) => GameEvents.current.PressButton(a));
        }
    }

}
