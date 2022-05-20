using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowManager : MonoBehaviour
{
    public GridManager gridLayOut;
    public OverallData overallData;
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
                gridLayOut.GetInput(guess);
                string result = overallData.guess.Remove(overallData.guess.Length - 1);
                overallData.guess = result;
            }
        }else if(guess == "Enter"){
            if(overallData.guess.Length == overallData.answer.Length)
            {
                gridLayOut.CheckInput(wordLength, overallData.answer);
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
                gridLayOut.GetInput(guess);
            }
        }
    }
}
