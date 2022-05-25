using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPopup : MonoBehaviour
{
    public TMPro.TextMeshProUGUI resultText;
    public TMPro.TextMeshProUGUI answerText;
    public ProgressBar[] progressBars;

    public void SetResult(int index,float score)
    {
        progressBars[index].SetValue(score);
    }

    public void ResetResult()
    {
        foreach (ProgressBar item in progressBars)
        {
            item.SetValue(0f);
        }
    }
}
