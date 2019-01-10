using UnityEngine;
using System.Collections;

public class BezierCurve : Line
{
    private const int approxSteps = 10;

    public Vector3 controlPoint1;
    public Vector3 controlPoint2;

    public override void Reset()
    {
        base.Reset();

        controlPoint1 = new Vector3(0.5f, 0f, 1f);
        controlPoint1 = new Vector3(-0.5f, 0f, 1f);
    }

    public Vector3 GetPoint(float t)
    {
        // Cubic Bezier formula
        return Mathf.Pow(1f - t, 3) * p1
            + 3f * Mathf.Pow(1f - t, 2) * t * controlPoint1
            + 3f * (1f - t) * Mathf.Pow(t, 2f) * controlPoint2
            + Mathf.Pow(t, 3) * p2;
    }

    public override void TranslatePoints(Vector3 amount)
    {
        base.TranslatePoints(amount);

        controlPoint1 += amount;
        controlPoint2 += amount;
    }

    public override float GetLength()
    {
        float finalLength = 0f;

        float delta = 1f / approxSteps;

        Vector3 previousPoint = p1;

        for (int i = 1; i <= approxSteps; i++)
        {
            Vector3 point = GetPoint(delta * i);

            finalLength += Vector3.Distance(point, previousPoint);

            previousPoint = point;
        }

        return finalLength;
    }
}
