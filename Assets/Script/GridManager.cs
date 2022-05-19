using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public AnsField ansField;
    int rowAmount = 6;
    public List<AnsField> ansFieldsList;
    public int gridRow;
    public int gridCollum;

    // void Awake() 
    // {
    //     GameEvents.current.onButtonPress += GetInput;
    // }
    public void BuildAnsField(int wordLength)
    {
        GridLayoutGroup grid = GetComponent<GridLayoutGroup>();
        grid.constraintCount = wordLength;
        for(gridRow = 0;gridRow < rowAmount;gridRow++)
        {
            for(gridCollum = 0;gridCollum < wordLength;gridCollum++)
            {
                AnsField _ansField = Instantiate<AnsField>(ansField);
                _ansField.transform.SetParent(this.transform, false);
                ansFieldsList.Add(_ansField);
            }
        }
        gridCollum = gridRow = 0;
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

    public void GetInput(string letter)
    {
        Debug.Log($"Grid manager ansField list: {ansFieldsList.Count}");
        GridLayoutGroup grid = GetComponent<GridLayoutGroup>();
        if(letter == "del")
        {
            if(gridCollum > 0)
            {
                gridCollum--;
            }
            ansFieldsList[(grid.constraintCount * gridRow) + gridCollum].ansLetter.text = "";
        }else{
            if(gridCollum < grid.constraintCount)
            {
                if(letter == "")
                {
                    ansFieldsList[(grid.constraintCount * gridRow) + gridCollum].GetLetter("#");
                    gridCollum++;
                }else{ 
                    ansFieldsList[(grid.constraintCount * gridRow) + gridCollum].GetLetter(letter);
                    gridCollum++;
                }
            }
        }
    }

    public void CheckInput(int wordLength, string ansWord)
    {
        for(int index = 0;index < wordLength;index++)
        {
            ansFieldsList[(wordLength * gridRow) + index].CheckLetter(ansWord,index);
        }
    }

    // void OnDestroy() 
    // {
    //     GameEvents.current.onButtonPress -= GetInput;
    // }
}
