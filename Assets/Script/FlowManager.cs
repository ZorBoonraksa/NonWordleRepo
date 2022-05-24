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
        overallData.answer = CoreGame.GenWord();

        wordLength = overallData.answer.Length;

        gridLayOut.BuildAnsField(wordLength);

        overallData.guess = "";
    }

    public void OnResetPress()
    {
        overallData.answer = CoreGame.GenWord();

        wordLength = overallData.answer.Length;

        gridLayOut.ResetField(wordLength);

        overallData.guess = "";

        keyBoard.ResetInteractable();
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
            gridLayOut.ShowResult(i,CoreGame.CheckLetter(overallData.guess[i],i));
            keyBoard.OnInput(char.ToString(overallData.guess[i]),CoreGame.CheckLetter(overallData.guess[i],i));
        }
        if(overallData.guess != overallData.answer)
        {
            if(gridLayOut.gridRow < 5)
            {
                gridLayOut.gridRow++;
                gridLayOut.gridCollum = 0;
                overallData.guess = "";
            }else{
                Debug.Log("Nice try,the Answer is " + overallData.answer);
            }
        }else{
            Debug.Log("Win");
        }
    }
}
