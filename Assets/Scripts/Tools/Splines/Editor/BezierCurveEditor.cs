using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(BezierCurve))]
public class BezierCurveEditor : LineEditor
{
    // Control points of the curve in world space
    protected Vector3 worldCP1;
    protected Vector3 worldCP2;

    // Curve currently selected for editing
    private BezierCurve curve;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        curve = target as BezierCurve;

        Vector3 point1Input = EditorGUILayout.Vector3Field("Control Point 1", isWorldSpace ? curve.WorldControl1 : curve.LocalControl2);
        Vector3 point2Input = EditorGUILayout.Vector3Field("Control Point 2", isWorldSpace ? curve.WorldControl2 : curve.LocalControl2);

        if (isWorldSpace)
        {
            curve.WorldControl1 = point1Input;
            curve.WorldControl2 = point2Input;
        }
        else
        {
            curve.LocalControl1 = point1Input;
            curve.LocalControl2 = point2Input;
        }
    }

    protected override void OnSceneGUI()
    {
        base.OnSceneGUI();

        curve = target as BezierCurve;

        worldCP1 = curve.WorldControl1;
        worldCP2 = curve.WorldControl2;

        DrawPoint(ref worldCP1);
        DrawPoint(ref worldCP2);

        curve.WorldControl1 = worldCP1;
        curve.WorldControl2 = worldCP2;
    }

    protected override void DrawLine()
    {
        Handles.DrawBezier(worldP1, worldP2, worldCP1, worldCP2, Color.white, null, 2f);
    }
}
