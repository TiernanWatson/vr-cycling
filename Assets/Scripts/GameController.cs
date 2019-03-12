using UnityEngine;
using System.Collections;

public delegate void GameFinish();

public class GameController : MonoBehaviour
{
    public event GameFinish CrossFinishLine;

    // Singleton class
    private static GameController instance;

    // False if targetting by distance
    private bool isTimeTrial;

    // Total distance to cycle (set in start screen)
    private float cycleTarget;

    // Time player starts training
    private float startTime;

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
        startTime = Time.time;

        isTimeTrial = PlayerPrefs.GetString("workOutTarget").Equals("time");

        cycleTarget = PlayerPrefs.GetInt("primaryUnit") * (isTimeTrial ? 60f : 1000f) + PlayerPrefs.GetInt("secondaryUnit");

        float trackLength = layoutSpline.GetTotalLength();

        // Can't place finish line beyond track length unless a loop
        if (!layoutSpline.Loopable && cycleTarget > trackLength)
        {
            cycleTarget = trackLength;
        }

        PlaceFinishLine();
    }

    private void Update()
    {
        if (isTimeTrial)
        {
            if (startTime - Time.time <= 0f)
                FinishSession();
        }
    }

    private void PlaceFinishLine()
    {
        Vector3 lineForward;

        Vector3 point = layoutSpline.GetPointAtDistance(cycleTarget, out lineForward);

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
