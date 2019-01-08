using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Spline))]
public class SplineEditor : Editor
{
    Spline spline;

    public override void OnInspectorGUI()
    {
        spline = (Spline)target;

        spline.isLoop = EditorGUILayout.Toggle("Loopable", spline.isLoop);

        if (GUILayout.Button("Add Line"))
            spline.AddLine(false);

        if (GUILayout.Button("Add Curve"))
            spline.AddLine(true);

        if (GUILayout.Button("Remove Line/Curve"))
            spline.RemoveLine();
    }
}
