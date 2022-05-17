using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnsField : MonoBehaviour
{
    public TextMeshProUGUI ansLetter;
    public Image fieldImage;

    void Awake() 
    {
        ansLetter.text = ""; 
    }

    public void GetLetter(string letter)
    {
        ansLetter.text = letter;
    }

    public void CheckLetter(string word,int index)
    {
        char letter = char.Parse(ansLetter.text);
        for(int i = 0;i < word.Length;i++)
        {
            if(letter == word[i])
            {
                ChangeColor(index == i);
            }else{
                continue;
            }
        }
    }

    void ChangeColor(bool isPerfect)
    {
        if(isPerfect)
        {
            fieldImage.color = new Color(0.6745098f,0.8392157f,0.2117647f,1);
        }else{
            fieldImage.color = new Color(0.7647059f,0.9882353f,0.172549f,1);
        }
    }
}
