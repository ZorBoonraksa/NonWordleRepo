using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class CoreGame
{
    static int wordLength;
    static int minLength = 4;
    static int maxLength = 7;
    static Dictionary<char,List<int>> generatedWord = new Dictionary<char, List<int>>();
    public static string GenWord()
    {
        generatedWord.Clear();
        IGenWord genWord = new GenerateWord();
        wordLength = Random.Range(minLength,maxLength);
        string word = WordGen(genWord);
        for(int i = 0;i < wordLength;i++)
        {
            if(!generatedWord.ContainsKey(word[i]))
            {
                generatedWord.Add(word[i],new List<int>());
            }
            generatedWord[word[i]].Add(i);
        }
        return word;
    }

    static string WordGen(IGenWord myGenWord)
    {
        return myGenWord.GeneratingWord(wordLength);
    }

    public static int CheckLetter(char letter,int index)
    {
        int result;
        if(!generatedWord.ContainsKey(letter))
        {
            result = 3;
        }else{
            if(generatedWord[letter].Contains(index))
            {
                result = 1;
            }else{
                result = 2;
            }
        }
        return result;
    }
}
