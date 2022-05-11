using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    public TextMeshProUGUI alphabet;

    public void KeyPress()
    {
        Debug.Log(alphabet.text);
    }

    public void EnterKey()
    {
        Debug.Log("Enter");
    }

    public void DeleteKey()
    {
        Debug.Log("Delete");
    } 
}
