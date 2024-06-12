using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ReplacePrefabEditor : EditorWindow
{
    #region Self Variables

    private CD_Object cdObject;

    #endregion

    [MenuItem("Tool/ReplacePrefabEditor")]
    public static void ShowWindow()
    {
        GetWindow<ReplacePrefabEditor>(true);
    }

    private void OnGUI()
    {
        cdObject = (CD_Object)EditorGUILayout.ObjectField("CD Object", cdObject, typeof(CD_Object), true);

        if (GUILayout.Button("Replace Prefab"))
        {
            var allObjects = FindObjectsOfType<GameObject>(true);

            foreach (var obje in cdObject.objectData.objects)
            {
                
                
                foreach (var sahneobje in allObjects)
                {
                    if(sahneobje != null)
                    {
                       
                    
                        if (sahneobje.name.Contains(obje.name))
                        {
                             var newObj =PrefabUtility.InstantiatePrefab(obje);
                            
                             newObj.GameObject().transform.position = sahneobje.transform.position;
                             newObj.GameObject().transform.rotation = sahneobje.transform.rotation;
                             newObj.GameObject().transform.localScale = sahneobje.transform.localScale;
                             
                             DestroyImmediate(sahneobje);
                        }
                    }
                }
                
            }
        }
    }
}