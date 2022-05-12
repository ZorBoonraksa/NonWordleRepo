using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OverallData")]
public class OverallData : ScriptableObject
{
    public string answer;
    public string guess;
    public int minLength = 4;
    public int maxLength = 7;
    public bool isEqualLength;
    public int currentrow;
    public string currentGuess;
}
