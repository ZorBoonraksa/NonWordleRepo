using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowManager : MonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup;
    public GameObject ansBox;
    int rowAmount = 6;
    int wordLength;
    int minLength = 4;
    int maxLength = 7;
    public string answer;

    void Awake() 
    {
        IGenWord generateWord = new GenerateWord();
        
        wordLength = Random.Range(minLength,maxLength);

        answer = WordGen(generateWord);

        gridLayoutGroup.constraintCount = wordLength;
        for(int gridrow = 0;gridrow < rowAmount;gridrow++)
        {
            for(int gridcollum = 0;gridcollum < wordLength;gridcollum++)
            {
                GameObject ansField = Instantiate<GameObject>(ansBox);
                ansField.transform.SetParent(gridLayoutGroup.transform);
            }
        }
    }

    string WordGen(IGenWord myGenWord)
    {
        return myGenWord.GeneratingWord(wordLength);
    }
}
