using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public UnityEngine.UI.Slider progressBar;
    public UnityEngine.UI.Image barImage;
    public TMPro.TextMeshProUGUI progressValue;
    void Awake() 
    {
        SetStartValue();
    }

    public void SetStartValue()
    {
        barImage.color = new Color(0.6037736f,0.5718761f,0.5718761f,1);
        progressBar.maxValue = 100.0f;
        progressBar.value = 0.0f;
        progressValue.text = "0%";
    } 

    public void SetValue(float value)
    {
        if(value > 99.9f)
        {
            progressBar.value = 100.0f;
            progressValue.text = 100.0f + "%";
            barImage.color = new Color(0.6745098f,0.8392157f,0.2117647f,1);
        }else{
            progressBar.value = value;
            progressValue.text = (int)value + "%";
        }
    }
}
