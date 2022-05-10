using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGenWord
{
    string GeneratingWord(int wordLength);
}
public class GenerateWord : IGenWord
{
    public string GeneratingWord(int wordLength)
    {
        string word = "";
        for(int i = 0;i < wordLength;i++)
        {
            word += (char)('A' + Random.Range(0,26));
        }
        return word;
    }
}
