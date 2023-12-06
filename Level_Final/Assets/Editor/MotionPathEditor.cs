using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class MotionPathEditor : EditorWindow
{
    private MotionPathData motionPathData;
    private GameObject selectedObject;

    [MenuItem("Window/Motion Path Editor")]
    public static void ShowWindow()
    {
        GetWindow<MotionPathEditor>("Motion Path Editor");
    }

    void OnGUI()
    {
        GUILayout.Label("Motion Path Configuration", EditorStyles.boldLabel);

        selectedObject = EditorGUILayout.ObjectField("Target Object", selectedObject, typeof(GameObject), true) as GameObject;

        if (selectedObject != null && GUILayout.Button("Add Point"))
        {
            AddPointToMotionPath();
        }

        if (motionPathData != null)
        {
            for (int i = 0; i < motionPathData.points.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                motionPathData.points[i].position = EditorGUILayout.Vector3Field($"Point {i} Position", motionPathData.points[i].position);
                Vector3 eulerAngles = motionPathData.points[i].rotation.eulerAngles;
                eulerAngles = EditorGUILayout.Vector3Field($"Point {i} Rotation", eulerAngles);
                motionPathData.points[i].rotation = Quaternion.Euler(eulerAngles);
                motionPathData.points[i].speed = EditorGUILayout.FloatField($"Point {i} Speed", motionPathData.points[i].speed);
                EditorGUILayout.EndHorizontal();
            }
        }

        if (GUILayout.Button("Create/Update Motion Path"))
        {
            CreateOrUpdateMotionPath();
        }
    }

    private void AddPointToMotionPath()
    {
        if (motionPathData == null)
        {
            motionPathData = ScriptableObject.CreateInstance<MotionPathData>();
        }
        MotionPathPoint newPoint = new MotionPathPoint
        {
            position = selectedObject.transform.position,
            rotation = selectedObject.transform.rotation,
            speed = 1.0f // Default speed
        };
        motionPathData.points.Add(newPoint);
    }

    private void CreateOrUpdateMotionPath()
    {
        string path = EditorUtility.SaveFilePanelInProject(
            "Save Motion Path",
            "NewMotionPath",
            "asset",
            "Please enter a file name to save the motion path to");

        if (!string.IsNullOrEmpty(path))
        {
            AssetDatabase.CreateAsset(motionPathData, path);
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = motionPathData;
        }
    }
}
