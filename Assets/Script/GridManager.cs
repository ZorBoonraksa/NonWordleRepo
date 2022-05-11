using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject ansBox;
    int rowAmount = 6;
    public void BuildAnsField(int wordLength)
    {
        for(int gridrow = 0;gridrow < rowAmount;gridrow++)
        {
            for(int gridcollum = 0;gridcollum < wordLength;gridcollum++)
            {
                GameObject ansField = Instantiate(ansBox);
                ansField.transform.SetParent(this.transform, false);
            }
        }
    }

    public void ResetField(int wordLength)
    {
        foreach (Transform child in transform) 
        {
            Destroy(child.gameObject);
        }
        BuildAnsField(wordLength);
    }
}
