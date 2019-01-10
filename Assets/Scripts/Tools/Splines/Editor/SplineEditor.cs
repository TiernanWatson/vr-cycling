﻿using UnityEngine;
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

    private void OnSceneGUI()
    {
        foreach (Line l in spline.lineList)
        {
            if (l is BezierCurve)
            {
                BezierCurve b = (BezierCurve)l;
                Handles.DrawBezier(b.p1, b.p2, b.controlPoint1, b.controlPoint2, Color.white, null, 1f);
            }
            else
            {
                Handles.DrawLine(l.p1, l.p2);
            }
        }
    }
}
