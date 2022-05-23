using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AnsFieldList
{
    public List<AnsField> ansFields = new List<AnsField>();
}

public class GridManager : MonoBehaviour
{
    public AnsField ansField;
    int rowAmount = 6;
    public AnsFieldList[] ansFieldLists;
    public int gridRow;
    public int gridCollum;

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
                ansFieldLists[gridRow].ansFields.Add(_ansField);
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
        for(int i = 0;i < rowAmount;i++)
        {
            ansFieldLists[i].ansFields.Clear();
        }
        BuildAnsField(wordLength);
    }

    public void KeyInput(string letter)
    {
        GridLayoutGroup grid = GetComponent<GridLayoutGroup>();
        if(letter == "del")
        {
            if(gridCollum > 0)
            {
                gridCollum--;
            }
            ansFieldLists[gridRow].ansFields[gridCollum].ansLetter.text = "";
        }else{
            if(gridCollum < grid.constraintCount)
            {
                if(letter == "")
                {
                    ansFieldLists[gridRow].ansFields[gridCollum].GetLetter("#");
                    gridCollum++;
                }else{ 
                    ansFieldLists[gridRow].ansFields[gridCollum].GetLetter(letter);
                    gridCollum++;
                }
            }
        }
    }

    public void ShowResult(int index, int result)
    {
        ansFieldLists[gridRow].ansFields[index].ChangeColor(result);
    }
}
