using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(BezierCurve))]
public class BezierCurveEditor : LineEditor
{
    protected Vector3 worldCP1;
    protected Vector3 worldCP2;

    private BezierCurve curve;

    protected override void OnSceneGUI()
    {
        base.OnSceneGUI();

        curve = target as BezierCurve;

        worldCP1 = curve.transform.TransformPoint(curve.controlPoint1);
        worldCP2 = curve.transform.TransformPoint(curve.controlPoint2);

        DrawPoint(worldCP1, ref curve.controlPoint1);
        DrawPoint(worldCP2, ref curve.controlPoint2);

        Handles.DrawBezier(worldP1, worldP2, worldCP1, worldCP2, Color.white, null, 2f);
    }
}
