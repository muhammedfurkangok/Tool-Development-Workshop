using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;

#endif
using UnityEngine;

public class MultiplePrefabCreator : EditorWindow
{
    #region Self Variables

    public string text;

    #endregion
    // #k shift k ye basınca calissin, / yeni sekme
    
    [MenuItem("Tool/Multiple Prefab Creator")]
    public static void ShowIndex()
    {
        GetWindow<MultiplePrefabCreator>( true);
    }

    private void OnGUI()
    {
        text = EditorGUILayout.TextField("Name", text);
        
        var list = Selection.gameObjects;
        if(GUILayout.Button("Create Prefabs"))
        {
            for(int i = 0; i < list.Length; i++)
            {
                GameObject go = list[i];
                PrefabUtility.SaveAsPrefabAsset(go, "Assets/Prefabs/" + text + "_" + i + ".prefab");
            }
        }
    }
}
