using UnityEngine;
using System.Collections;

public delegate void GameFinish();

public class GameController : MonoBehaviour
{
    public event GameFinish CrossFinishLine;

    // Singleton class
    private static GameController instance;

    // Total distance to cycle (set in start screen)
    private float cycleDistance;

    // Spline describing track layout
    [SerializeField]
    private Spline layoutSpline;

    // Finish line prefab to spawn
    [SerializeField]
    private GameObject finishLine;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple game controllers in the scene.  Destroying: " + gameObject.name);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        cycleDistance = PlayerPrefs.GetInt("primaryUnit") * 1000f + PlayerPrefs.GetInt("secondaryUnit");

        float trackLength = layoutSpline.GetTotalLength();

        // Can't place finish line beyond track length unless a loop
        if (!layoutSpline.Loopable && cycleDistance > trackLength)
        {
            cycleDistance = trackLength;
        }

        //PlaceFinishLine();
    }

    private void PlaceFinishLine()
    {
        Vector3 lineForward;

        Vector3 point = layoutSpline.GetPointAtDistance(cycleDistance, out lineForward);

        Quaternion rotation = Quaternion.LookRotation(lineForward, Vector3.up);

        // Spawn finish line in direction line is going at correct distance
        Instantiate(finishLine, point, rotation);
    }

    public void FinishSession()
    {
        CrossFinishLine.Invoke();
    }

    #region Public Properties

    public static GameController Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("Trying to access non-existent game controller.");
            
            return instance;
        }
    }

    #endregion
}
