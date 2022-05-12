using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AnsField))]
public class AnsFieldEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Enter Leter"))
        {
            ((AnsField)target).GetLetter("Z");
        }
    }
}
