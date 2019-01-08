using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour
{
    public Vector3 p1, p2;

    public virtual void Reset()
    {
        // Makes sure handles are not covered by root
        p1 = new Vector3(-1f, 0f, 0f);
        p2 = new Vector3(1f, 0f, 0f);
    }

    public virtual void TranslatePoints(Vector3 amount)
    {
        p1 += amount;
        p2 += amount;
    }
}
