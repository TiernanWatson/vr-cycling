using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spline : MonoBehaviour
{
    public bool isLoop = true;

    public List<Line> lineList = new List<Line>();

    public void Reset()
    {
        lineList = new List<Line>();

        int childCount = transform.childCount;

        for (int i = childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    public void AddLine(bool isBezier)
    {
        // Need to make new Unity components this way
        GameObject toMake = new GameObject("SubLine " + lineList.Count.ToString());
        toMake.transform.parent = this.transform;

        if (isBezier)
            toMake.AddComponent<BezierCurve>();
        else
            toMake.AddComponent<Line>();

        Line newLine = toMake.GetComponent<Line>();

        // Attach new line to last line by moving desired amount
        if (lineList.Count > 0)
        {
            Vector3 lastPoint = lineList[lineList.Count - 1].p2;
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
}
