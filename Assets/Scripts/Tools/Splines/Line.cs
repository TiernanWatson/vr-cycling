using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour
{
    [SerializeField]
    protected Vector3 point1, point2;

    [SerializeField]
    protected Vector3 localPoint1, localPoint2;

    public virtual void Reset()
    {
        // Makes sure handles are not covered by root
        LocalPoint1 = new Vector3(-1f, 0f, 0f);
        LocalPoint2 = new Vector3(1f, 0f, 0f);
    }

    public virtual void TranslatePoints(Vector3 amount)
    {
        WorldPoint1 += amount;
        WorldPoint2 += amount;
    }

    public virtual Vector3 GetPointDistance(float distance)
    {
        float distanceWeight = distance / GetLength();

        return Vector3.Lerp(point1, point2, distanceWeight);
    }

    public virtual Vector3 GetLineForward()
    {
        return (point2 - point1).normalized;
    }

    public virtual float GetLength()
    {
        return Vector3.Distance(point2, point1);
    }

    #region Public Properties

    public Vector3 WorldPoint1
    {
        get { return point1; }
        set
        {
            point1 = value;

            // Transform world space to local space
            localPoint1 = transform.InverseTransformPoint(value);
        }
    }

    public Vector3 WorldPoint2
    {
        get { return point2; }
        set
        {
            point2 = value;

            // Transform world space to local space
            localPoint2 = transform.InverseTransformPoint(value);
        }
    }

    public Vector3 LocalPoint1
    {
        get { return localPoint1; }
        set
        {
            localPoint1 = value;

            // Transform local point to world space
            point1 = transform.TransformPoint(value);
        }
    }

    public Vector3 LocalPoint2
    {
        get { return localPoint2; }
        set
        {
            localPoint2 = value;

            // Transform local point to world space
            point2 = transform.TransformPoint(value);
        }
    }

    #endregion
}
