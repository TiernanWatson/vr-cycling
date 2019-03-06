using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Spline : MonoBehaviour
{
    [SerializeField]
    private bool isLoop = true;

    [SerializeField]
    private List<Line> lineList = new List<Line>();

    public void Reset()
    {
        lineList = new List<Line>();

        int childCount = transform.childCount;

        // Destroys all child curves/lines
        for (int i = childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        // Check that list has correct lines (might not if someone deletes something in editor)
        if (transform.childCount != lineList.Count)
        {
            UpdateList();
        }
    }

    private void UpdateList()
    {
        lineList = new List<Line>();

        // Go through each child and add its line component to list
        for (int i = 0; i < transform.childCount; i++)
        {
            Line line = transform.GetChild(i).GetComponent<Line>();

            if (line)
            {
                lineList.Add(line);
            }
            else
            {
                Debug.LogWarning("Something in the spline that is not a line: " + gameObject.name);
            }
        }
    }

    public void AddLine<LineType>() where LineType : Line
    {
        // Need to make new Unity components this way
        GameObject toMake = new GameObject("SubLine " + lineList.Count.ToString());
        toMake.transform.parent = this.transform;
        toMake.AddComponent<LineType>();
        
        Line newLine = toMake.GetComponent<Line>();

        // Attach new line to last line by moving desired amount
        if (lineList.Count > 0)
        {
            Vector3 lastPoint = lineList[lineList.Count - 1].WorldPoint2;
            newLine.TranslatePoints(lastPoint);
        }

        lineList.Add(newLine);
    }

    public void RemoveLine()
    {
        DestroyImmediate(lineList[lineList.Count - 1].gameObject);
        lineList.RemoveAt(lineList.Count - 1);
    }

    public Vector3 GetPointAtDistance(float distance, out Vector3 forward)
    {
        float distanceLeft = distance;

        Debug.Log("There is: " + distance + "m to go");

        int i = 0;
        while (lineList[i].GetLength() < distanceLeft)
        {
            distanceLeft -= lineList[i].GetLength();
            i++;
            Debug.Log("There is: " + distanceLeft + "m to go");
        }

        forward = lineList[i].GetLineForward();

        return lineList[i].GetPointDistance(distanceLeft);
    }

    public float GetTotalLength()
    {
        float finalLength = 0f;

        foreach (Line l in lineList)
        {
            finalLength += l.GetLength();
        }

        return finalLength;
    }

    #region Public Properties

    public bool Loopable
    {
        get { return isLoop; }
    }

    public List<Line> Lines
    {
        get { return lineList; }
    }

    #endregion
}
