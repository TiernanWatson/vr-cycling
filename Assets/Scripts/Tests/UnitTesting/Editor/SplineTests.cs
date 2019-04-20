using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class SplineTests {

	[Test]
	public void AddLineTest()
	{
        GameObject splineObj = new GameObject("Spline");
        Spline spline = splineObj.AddComponent<Spline>();

        int originalSize = spline.Lines.Count;

        spline.AddLine<Line>();

        int newSize = spline.Lines.Count;

        Assert.AreEqual(1, newSize - originalSize);
	}

    [Test]
    public void RemoveLineTest()
    {
        GameObject splineObj = new GameObject("Spline");
        Spline spline = splineObj.AddComponent<Spline>();

        int originalSize = spline.Lines.Count;

        spline.AddLine<Line>();
        spline.RemoveLine();

        int newSize = spline.Lines.Count;

        Assert.AreEqual(0, newSize - originalSize);
    }
}
