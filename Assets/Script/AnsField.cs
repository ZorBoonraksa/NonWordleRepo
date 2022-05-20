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
                if(index == i)
                {
                    ChangeColor(1);
                    return;
                }else{
                    ChangeColor(2);
                    return;
                }
                
            }else{
                continue;
            }
        }
        ChangeColor(3);
    }

    void ChangeColor(int checkCase)
    {
        switch (checkCase)
        {
            case 1:
                fieldImage.color = new Color(0.6745098f,0.8392157f,0.2117647f,1);
                break;
            case 2:
                fieldImage.color = new Color(0.7647059f,0.9882353f,0.172549f,1);
                break;
            case 3:
                fieldImage.color = new Color(0.6037736f,0.5718761f,0.5718761f,1);
                break;       
        }
    }
}
