using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Line))]
public class LineEditor : Editor
{
    // Sizes used for selecting points in the scene
    private const float HANDLE_SIZE = 0.05f;
    private const float PICK_SIZE = 0.05f;

    // True if editor is in world space editing mode
    protected bool isWorldSpace;

    // Point developer has currently selected for editing
    private Vector3 selectedPoint;

    // World space points of the line start and end (cant ref properties in draw point)
    protected Vector3 worldP1;
    protected Vector3 worldP2;

    // Line that is being edited
    private Line line;

    private void Awake()
    {
        isWorldSpace = Tools.pivotRotation == PivotRotation.Global;
    }

    public override void OnInspectorGUI()
    {
        line = target as Line;

        // Allow user to switch between world and local space editing
        isWorldSpace = Tools.pivotRotation == PivotRotation.Global;

        Vector3 point1Input = EditorGUILayout.Vector3Field("Point 1", isWorldSpace ? line.WorldPoint1 : line.LocalPoint1);
        Vector3 point2Input = EditorGUILayout.Vector3Field("Point 1", isWorldSpace ? line.WorldPoint2 : line.LocalPoint2);

        if (isWorldSpace)
        {
            line.WorldPoint1 = point1Input;
            line.WorldPoint2 = point2Input;
        }
        else
        {
            line.LocalPoint1 = point1Input;
            line.LocalPoint2 = point2Input;
        }
    }

    protected virtual void OnSceneGUI()
    {
        line = target as Line;

        worldP1 = line.WorldPoint1;
        worldP2 = line.WorldPoint2;

        DrawLine();

        DrawPoint(ref worldP1);
        DrawPoint(ref worldP2);

        line.WorldPoint1 = worldP1;
        line.WorldPoint2 = worldP2;
    }

    protected virtual void DrawLine()
    {
        Handles.DrawLine(worldP1, worldP2);
    }

    protected void DrawPoint(ref Vector3 point)
    {
        Quaternion handleRotation = isWorldSpace ? Quaternion.identity : line.transform.rotation;

        if (selectedPoint.Equals(point))
        {
            EditorGUI.BeginChangeCheck();

            Vector3 handlePoint = Handles.DoPositionHandle(point, handleRotation);

            // Handle was moved if true so update referenced point
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(line, "Line Point Move");
                EditorUtility.SetDirty(line);

                point = selectedPoint = handlePoint;
            }
        }
        else
        {
            // Handle selection of this point if its not currently selected
            float sizeMultiplier = HandleUtility.GetHandleSize(point);

            if (Handles.Button(point, handleRotation, sizeMultiplier * HANDLE_SIZE, sizeMultiplier * PICK_SIZE, Handles.DotCap))
            {
                selectedPoint = point;
            }
        }
    }
    
}
