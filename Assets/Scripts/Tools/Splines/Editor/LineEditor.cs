using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Line))]
public class LineEditor : Editor
{
    private const float handleSize = 0.05f;
    private const float pickSize = 0.05f;

    private Vector3 currentPoint;

    protected Vector3 worldP1;
    protected Vector3 worldP2;

    protected Quaternion gizmoRotation;
    protected Transform targetTransform;

    private Line line;

    protected virtual void OnSceneGUI()
    {
        line = target as Line;
        targetTransform = line.transform;

        // Transform line points from local to world space
        worldP1 = line.transform.TransformPoint(line.p1);
        worldP2 = line.transform.TransformPoint(line.p2);

        Handles.DrawLine(worldP1, worldP2);

        // Checks if Unity is in global or local mode
        gizmoRotation = Tools.pivotRotation == PivotRotation.Global 
            ? Quaternion.identity 
            : line.transform.rotation;

        DrawPoint(worldP1, ref line.p1);
        DrawPoint(worldP2, ref line.p2);
    }

    protected void DrawPoint(Vector3 point, ref Vector3 update)
    {
        if (currentPoint.Equals(point))
        {
            EditorGUI.BeginChangeCheck();

            Vector3 handlePoint = Handles.DoPositionHandle(point, gizmoRotation);

            // Handle was moved if true so update referenced point
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(line, "Line Point Move");
                EditorUtility.SetDirty(line);

                update = targetTransform.InverseTransformPoint(handlePoint);
                currentPoint = handlePoint;
            }

            return;
        }

        // Allow point to be selected
        float sizeMultiplier = HandleUtility.GetHandleSize(point);

        if (Handles.Button(point, gizmoRotation, sizeMultiplier * handleSize, sizeMultiplier * pickSize, Handles.DotCap))
        {
            currentPoint = point;
        }
    }
    
}
