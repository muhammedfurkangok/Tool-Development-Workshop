using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MeshModifier : EditorWindow
{

    #region Self Variables

    private Mesh mesh1;
    private Mesh mesh2;

    #endregion
    
    [MenuItem("Tool/MeshModifier")]
    public static void ShowIndex()
    {
        GetWindow<MeshModifier>(true);
    }

    private void OnGUI()
    {
        GUILayout.Label("Select Meshes to Combine");
        
        mesh1 = (Mesh)EditorGUILayout.ObjectField("Mesh 1", mesh1, typeof(Mesh), true);
        mesh2 = (Mesh)EditorGUILayout.ObjectField("Mesh 2", mesh2, typeof(Mesh), true);
        
        if (GUILayout.Button("Combine Meshes"))
        {
            var meshFilters = FindObjectsOfType<MeshFilter>(); // Find all MeshFilter instances

            foreach (var obj in meshFilters)
            {
                if (obj.sharedMesh == mesh1) // Use sharedMesh instead of mesh
                {
                    Vector3 originalPosition = obj.transform.position; // Store original position
                    Quaternion originalRotation = obj.transform.rotation; // Store original rotation
    
                    obj.sharedMesh = mesh2; // Replace mesh1 with mesh2
                    obj.transform.rotation = originalRotation; // Reapply original rotation
                    obj.transform.position = originalPosition; // Reapply original position
                    obj.transform.localScale = new Vector3(10, 10, 10); // Set local scale
                    
                    EditorUtility.SetDirty(obj); // Mark the object as dirty
                }
            }
        }

    }
}