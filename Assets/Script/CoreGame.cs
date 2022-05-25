using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class CoreGame
{
    static int wordLength;
    static int minLength = 4;
    static int maxLength = 7;
    static Dictionary<char,List<int>> generatedWord = new Dictionary<char, List<int>>();
    public static List<float> progress = new List<float>();
    public static string GenWord()
    {
        progress.Clear();
        for(int i = 0;i < 6;i++)
        {
            progress.Add(0f);
        }
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

    public static CheckingState CheckLetter(char letter,int index,int row,bool doProgressing)
    {
        CheckingState result;
        if(!generatedWord.ContainsKey(letter))
        {
            result = CheckingState.Wrong;
        }else{
            if(generatedWord[letter].Contains(index))
            {
                result = CheckingState.Correct;
                if(doProgressing)
                {
                    progress[row] += 100.0f / wordLength;
                }
            }else{
                result = CheckingState.WrongIndex;
                if(doProgressing)
                {
                    progress[row] += 100.0f / (wordLength * 2);
                }
            }
        }
        return result;
    }
}
