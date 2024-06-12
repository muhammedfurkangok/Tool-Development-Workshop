using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class RenameEditor : EditorWindow
{

    #region Self Variables

    public string text;

    #endregion
    // #k shift k ye basınca calissin, / yeni sekme
    
    [MenuItem("RuntimeEditor/ShowIndex #Z")]
    public static void ShowIndex()
    {
        GetWindow<RenameEditor>( true);
    }

    private void OnGUI()
    {
           text = EditorGUILayout.TextField("Name", text);
            if (GUILayout.Button("Rename Editor"))
            {
               for(int i = 0; i < Selection.gameObjects.Length; i++)
                {
                    Selection.gameObjects[i].name = text + "_" + i;
                }
                
            }
    }
}
