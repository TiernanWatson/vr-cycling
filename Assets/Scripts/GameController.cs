using UnityEngine;
using System.Collections;

public delegate void GameFinish();

public class GameController : MonoBehaviour
{
    public event GameFinish CrossFinishLine;

    // Singleton class
    private static GameController instance;

    // False if player hsa crossed finish line
    private bool gameFinished;

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

        cycleTarget = PlayerPrefs.GetInt("primaryUnit") * (isTimeTrial ? 60f * 60f : 1000f) 
            + PlayerPrefs.GetInt("secondaryUnit") * (isTimeTrial ? 60f : 1f);

        // Only want to place finish if not a time trial
        if (!isTimeTrial)
        {
            float trackLength = layoutSpline.GetTotalLength();

            // Can't place finish line beyond track length unless a loop
            if (!layoutSpline.Loopable && cycleTarget > trackLength)
            {
                cycleTarget = trackLength;
            }

            PlaceFinishLine();
        }
    }

    private void Update()
    {
        if (isTimeTrial)
        {
            if (Time.time - startTime >= cycleTarget)
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
        gameFinished = true;
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

    public bool GameFinished
    {
        get { return gameFinished; }
    }

    #endregion
}
