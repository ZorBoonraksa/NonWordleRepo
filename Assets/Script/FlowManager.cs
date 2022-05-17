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

        overallData.currentrow = 0;
    }

    public void OnResetPress()
    {
        IGenWord generateWord = new GenerateWord();
        
        wordLength = Random.Range(overallData.minLength,overallData.maxLength);

        overallData.answer = WordGen(generateWord);

        gridLayOut.ResetField(wordLength);

        overallData.guess = "";

        overallData.currentrow = 0;
    } 
    string WordGen(IGenWord myGenWord)
    {
        return myGenWord.GeneratingWord(wordLength);
    }

    public void EnterKey()
    {
        if(overallData.isEqualLength)
        {
            gridLayOut.CheckInput(wordLength, overallData.answer);
            gridLayOut.gridRow++;
            gridLayOut.gridCollum = 0;
            overallData.guess = "";
        }else{
            Debug.Log("Invalid Input");
        }
    }
}
