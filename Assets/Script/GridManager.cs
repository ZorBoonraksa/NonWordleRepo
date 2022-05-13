using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public OverallData overallData;
    public AnsField ansField;
    int rowAmount = 6;
    public List<AnsField> ansFieldsList;

    void Awake() 
    {
        GameEvents.current.onButtonPress += GetInput;    
    }
    public void BuildAnsField(int wordLength)
    {
        GridLayoutGroup grid = GetComponent<GridLayoutGroup>();
        grid.constraintCount = wordLength;
        for(int gridrow = 0;gridrow < rowAmount;gridrow++)
        {
            for(int gridcollum = 0;gridcollum < wordLength;gridcollum++)
            {
                AnsField _ansField = Instantiate<AnsField>(ansField);
                _ansField.transform.SetParent(this.transform, false);
                ansFieldsList.Add(_ansField);
            }
        }
    }

    public void ResetField(int wordLength)
    {
        foreach (Transform child in transform) 
        {
            Destroy(child.gameObject);
        }
        ansFieldsList.Clear();
        BuildAnsField(wordLength);
    }

    public void GetInput()
    {
        if(overallData.guess.Length < overallData.answer.Length)
        {
            if(overallData.currentGuess == "")
            {
                ansFieldsList[(overallData.answer.Length * overallData.currentrow) + overallData.guess.Length].GetLetter("#");
            }else{ 
                ansFieldsList[(overallData.answer.Length * overallData.currentrow) + overallData.guess.Length].GetLetter(overallData.currentGuess);
                overallData.guess += overallData.currentGuess;
            }
        }else{
            return;
        }
    }

    public void CheckInput(int wordLength)
    {
        for(int index = 0;index < wordLength;index++)
        {
            ansFieldsList[(overallData.answer.Length * overallData.currentrow) + index].CheckLetter(overallData.guess[index],overallData.answer,index);
        }
    }

    void OnDestroy() 
    {
        GameEvents.current.onButtonPress -= GetInput;
    }
}
