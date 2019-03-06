using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Spline))]
public class SplineEditor : Editor
{
    // Spline currently being edited
    private Spline spline;

    // Spline being edited but serialized (prevents having to break encapsulation)
    private SerializedObject splineObj;
    private SerializedProperty loopable;

    private void OnEnable()
    {
        spline = target as Spline;
        splineObj = new SerializedObject(target);
        loopable = splineObj.FindProperty("isLoop");
    }

    public override void OnInspectorGUI()
    {
        splineObj.Update();

        loopable.boolValue = EditorGUILayout.Toggle("Loopable", loopable.boolValue);

        splineObj.ApplyModifiedProperties();

        if (GUILayout.Button("Add Line"))
            spline.AddLine<Line>();

        if (GUILayout.Button("Add Curve"))
            spline.AddLine<BezierCurve>();

        if (GUILayout.Button("Remove Line/Curve"))
            spline.RemoveLine();
    }

    private void OnSceneGUI()
    {
        EditorGUI.BeginChangeCheck();

        Vector3 tryMove = Handles.PositionHandle(spline.transform.position, Quaternion.identity);

        if (EditorGUI.EndChangeCheck())
            spline.transform.position = tryMove;

        foreach (Line l in spline.Lines)
        {
            // User may have moved position so translate points
            l.TranslatePoints(tryMove - spline.transform.position);

            if (l is BezierCurve)
            {
                BezierCurve b = l as BezierCurve;
                Handles.DrawBezier(b.WorldPoint1, b.WorldPoint2, b.WorldControl1, b.WorldControl2, Color.white, null, 1f);
            }
            else
            {
                Handles.DrawLine(l.WorldPoint1, l.WorldPoint2);
            }
        }
    }
}
