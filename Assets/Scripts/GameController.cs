using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    [SerializeField]
    float cycleDistance;

    [SerializeField]
    Spline layoutSpline;

    [SerializeField]
    GameObject finishLine;

    void Start()
    {
        //cycleDistance = PlayerPrefs.GetFloat("primaryUnit") * 1000f + PlayerPrefs.GetFloat("secondaryUnit");

        PlaceFinishLine();
    }

    void PlaceFinishLine()
    {
        Vector3 lineForward;

        Vector3 point = layoutSpline.GetPointAtDistance(cycleDistance, out lineForward);

        Quaternion rotation = Quaternion.LookRotation(lineForward, Vector3.up);

        rotation *= Quaternion.Euler(-90f, 0f, 0f);

        Debug.Log("Making finish line");

        Instantiate(finishLine, point, rotation);
    }
}
