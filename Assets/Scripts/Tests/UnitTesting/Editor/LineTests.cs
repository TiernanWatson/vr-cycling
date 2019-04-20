using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class LineTests {

	[Test]
	public void TranslateTest()
	{
        GameObject lineObj = new GameObject("Line");
        Line line = lineObj.AddComponent<Line>();

        line.WorldPoint1 = new Vector3(0f, 0f, 0f);
        line.WorldPoint2 = new Vector3(1f, 1f, 1f);

        line.TranslatePoints(Vector3.one);

        Assert.AreEqual(line.WorldPoint1.x, 1f);
        Assert.AreEqual(line.WorldPoint1.y, 1f);
        Assert.AreEqual(line.WorldPoint1.z, 1f);

        Assert.AreEqual(line.WorldPoint2.x, 2f);
        Assert.AreEqual(line.WorldPoint2.y, 2f);
        Assert.AreEqual(line.WorldPoint2.z, 2f);
    }

    [Test]
    public void GetLengthTest()
    {
        GameObject lineObj = new GameObject("Line");
        Line line = lineObj.AddComponent<Line>();

        line.WorldPoint1 = new Vector3(0f, 0f, 0f);
        line.WorldPoint2 = new Vector3(1f, 1f, 1f);

        float length = line.GetLength();

        Assert.AreEqual(Mathf.Sqrt(3f), length);
    }

    [Test]
    public void GetPointTest()
    {
        GameObject lineObj = new GameObject("Line");
        Line line = lineObj.AddComponent<Line>();

        line.WorldPoint1 = new Vector3(0f, 0f, 0f);
        line.WorldPoint2 = new Vector3(0f, 0f, 2f);

        Vector3 midPoint = line.GetPointDistance(1f);

        Assert.AreEqual(0f, midPoint.x);
        Assert.AreEqual(0f, midPoint.y);
        Assert.AreEqual(1f, midPoint.z);
    }

    [Test]
    public void GetForwardTest()
    {
        GameObject lineObj = new GameObject("Line");
        Line line = lineObj.AddComponent<Line>();

        line.WorldPoint1 = new Vector3(0f, 0f, 0f);
        line.WorldPoint2 = new Vector3(1f, 1f, 1f);

        Vector3 forward = line.GetLineForward();

        Assert.AreEqual(1f / Mathf.Sqrt(3f), forward.x);
        Assert.AreEqual(1f / Mathf.Sqrt(3f), forward.y);
        Assert.AreEqual(1f / Mathf.Sqrt(3f), forward.z);
    }
}
