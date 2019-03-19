using UnityEngine;
using System.Collections;

public class BezierCurve : Line
{
    // Number of divisions in bezier approximation
    private const int LENGTH_ACCURACY = 10;

    // World space
    [SerializeField]
    protected Vector3 controlPoint1, controlPoint2;

    // Relative to parent
    [SerializeField]
    protected Vector3 localControlPoint1, localControlPoint2;

    public override void Reset()
    {
        base.Reset();

        controlPoint1 = new Vector3(0.5f, 0f, 1f);
        controlPoint1 = new Vector3(-0.5f, 0f, 1f);
    }

    public Vector3 GetPoint(float t)
    {
        // Cubic Bezier formula
        return Mathf.Pow(1f - t, 3) * point1
            + 3f * Mathf.Pow(1f - t, 2) * t * controlPoint1
            + 3f * (1f - t) * Mathf.Pow(t, 2f) * controlPoint2
            + Mathf.Pow(t, 3) * point2;
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
        float delta = 1f / LENGTH_ACCURACY;

        Vector3 previousPoint = point1;

        for (int i = 1; i <= LENGTH_ACCURACY; i++)
        {
            Vector3 point = GetPoint(delta * i);

            finalLength += Vector3.Distance(point, previousPoint);
            previousPoint = point;
        }

        return finalLength;
    }

    #region Public Properties

    public Vector3 WorldControl1
    {
        get { return controlPoint1; }
        set
        {
            controlPoint1 = value;

            // Transform world space to local space
            localControlPoint1 = transform.InverseTransformPoint(value);
        }
    }

    public Vector3 WorldControl2
    {
        get { return controlPoint2; }
        set
        {
            controlPoint2 = value;

            // Transform world space to local space
            localControlPoint2 = transform.InverseTransformPoint(value);
        }
    }

    public Vector3 LocalControl1
    {
        get { return localControlPoint1; }
        set
        {
            localControlPoint1 = value;

            // Transform local point to world space
            controlPoint1 = transform.TransformPoint(value);
        }
    }

    public Vector3 LocalControl2
    {
        get { return localControlPoint2; }
        set
        {
            localControlPoint2 = value;

            // Transform local point to world space
            controlPoint2 = transform.TransformPoint(value);
        }
    }

    #endregion
}
