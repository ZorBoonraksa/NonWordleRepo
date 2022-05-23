using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowManager : MonoBehaviour
{
    public GridManager gridLayOut;
    public OverallData overallData;
    public KeyBoard keyBoard;
    int wordLength;

    void Awake() 
    {
        IGenWord generateWord = new GenerateWord();
        
        wordLength = Random.Range(overallData.minLength,overallData.maxLength);

        overallData.answer = WordGen(generateWord);

        gridLayOut.BuildAnsField(wordLength);

        overallData.guess = "";
    }

    public void OnResetPress()
    {
        IGenWord generateWord = new GenerateWord();
        
        wordLength = Random.Range(overallData.minLength,overallData.maxLength);

        overallData.answer = WordGen(generateWord);

        gridLayOut.ResetField(wordLength);

        overallData.guess = "";

        keyBoard.ResetInteractable();
    } 
    string WordGen(IGenWord myGenWord)
    {
        return myGenWord.GeneratingWord(wordLength);
    }

    public void GetKey(string guess)
    {
        //Debug.Log($"Get key: {guess}");
        if(guess == "del"){
            if(overallData.guess.Length > 0)
            {
                gridLayOut.KeyInput(guess);
                string result = overallData.guess.Remove(overallData.guess.Length - 1);
                overallData.guess = result;
            }
        }else if(guess == "Enter"){
            if(overallData.guess.Length == overallData.answer.Length)
            {
                Result();
                gridLayOut.gridRow++;
                gridLayOut.gridCollum = 0;
                overallData.guess = "";
            }else{
                Debug.Log("Invalid Input");
                return;
            }
        }else{
            if(overallData.guess.Length < overallData.answer.Length)
            {
                overallData.guess += guess;
                gridLayOut.KeyInput(guess);
            }
        }
    }

    void Result()
    {
        for(int i = 0;i < wordLength;i++)
        {
            gridLayOut.ShowResult(i,CheckLetter(overallData.answer,overallData.guess[i],i));
            keyBoard.OnInput(char.ToString(overallData.guess[i]),CheckLetter(overallData.answer,overallData.guess[i],i));
        }
    }

    public int CheckLetter(string word,char letter,int index)
    {
        int result = 3;
        bool isCorrect = false;
        for(int i = 0;i < word.Length;i++)
        {
            if(letter == word[i])
            {
                if(index == i)
                {
                    isCorrect = true;
                    result = 1;
                }
                if(isCorrect == false)
                {
                    result = 2;
                }
            }else{
                continue;
            }
        }
        return result;        
    }
}
