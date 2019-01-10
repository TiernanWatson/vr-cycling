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
        GameObject toMake = new GameObject("SubLine " + lineList.Count.ToString());
        toMake.transform.parent = this.transform;

        if (isBezier)
            toMake.AddComponent<BezierCurve>();
        else
            toMake.AddComponent<Line>();

        Line newLine = toMake.GetComponent<Line>();

        // So lines connect move subline to end of last
        if (lineList.Count > 0)
        {
            Line lastLine = lineList[lineList.Count - 1];
            newLine.TranslatePoints(lastLine.p2 - lastLine.p1);
        }

        lineList.Add(newLine);
    }

    public void RemoveLine()
    {
        DestroyImmediate(lineList[lineList.Count - 1].gameObject);
        lineList.RemoveAt(lineList.Count - 1);
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
