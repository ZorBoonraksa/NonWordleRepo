using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public OverallData overallData;
    public AnsField ansField;
    int rowAmount = 6;
    public List<AnsField> ansFieldsList;
    public void BuildAnsField(int wordLength)
    {
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
        ansFieldsList[overallData.currentrow + (rowAmount * overallData.guess.Length)].GetLetter(overallData.currentGuess);
        overallData.guess += overallData.currentGuess;
    }
}
