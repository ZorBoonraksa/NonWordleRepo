using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowManager : MonoBehaviour
{
    public GridManager gridLayOut;
    public OverallData overallData;
    public KeyBoard keyBoard;
    public ResultPopup result;
    int wordLength;

    void Awake() 
    {
        StartState();

        gridLayOut.BuildAnsField(wordLength);
    }

    public void OnResetPress()
    {
        StartState();

        gridLayOut.ResetField(wordLength);

        keyBoard.ResetInteractable();
    }

    void StartState()
    {
        
        result.gameObject.SetActive(false);

        overallData.answer = CoreGame.GenWord();

        wordLength = overallData.answer.Length;

        overallData.guess = "";

        result.ResetResult();
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
            gridLayOut.ShowResult(i,CoreGame.CheckLetter(overallData.guess[i],i,gridLayOut.gridRow,true));
            keyBoard.OnInput(char.ToString(overallData.guess[i]),CoreGame.CheckLetter(overallData.guess[i],i,gridLayOut.gridRow,false));
            result.SetResult(gridLayOut.gridRow,CoreGame.progress[gridLayOut.gridRow]);
        }
        if(overallData.guess != overallData.answer)
        {
            if(gridLayOut.gridRow < 5)
            {
                gridLayOut.gridRow++;
                gridLayOut.gridCollum = 0;
                overallData.guess = "";
            }else{
                result.resultText.text = "Try Again";
                result.answerText.text = overallData.answer;
                result.gameObject.SetActive(true);
            }
        }else{
            result.resultText.text = "You Win";
            result.answerText.text = overallData.answer;
            result.gameObject.SetActive(true);
        }
    }
}
