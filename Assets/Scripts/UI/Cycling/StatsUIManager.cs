using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatsUIManager : MonoBehaviour
{
    // Stops updates happening after finish
    private bool haltUpdate = false;

    // Holds all the players statistics
    [SerializeField]
    private StatsManager statsManager;

    // Mid-game statistic displayers
    [SerializeField]
    private GameObject stateTextContainer;
    [SerializeField]
    private Text statTextBox;

    // End result displayers
    [SerializeField]
    private GameObject recordContainer;
    [SerializeField]
    private Text endTopSpeed;
    [SerializeField]
    private Text endTopBPM;
    [SerializeField]
    private Text endTimeTaken;
    [SerializeField]
    private Button continueBtn;

	private void Start()
    {
        if (statsManager == null)
        {
            Debug.LogError("No StatsManager assigned in StatsUIManager.  Destroying object.");
            Destroy(this.gameObject);
            return;
        }

        DefaultActiveStates();

        GameController.Instance.CrossFinishLine += ShowResultScreen;
	}

    private void DefaultActiveStates()
    {
        statTextBox.gameObject.SetActive(true);
        recordContainer.SetActive(false);
    }

    private void OnDisable()
    {
        GameController.Instance.CrossFinishLine -= ShowResultScreen;
    }

    private void Update()
    {
        if (VZPlayer.Controller.RightRight.Down || Input.GetKeyDown(KeyCode.KeypadEnter))
            continueBtn.onClick.Invoke();

        if (haltUpdate)
            return;

        statTextBox.text = StatsToText(statsManager.Stats);
	}

    private string StatsToText(PlayerStats stats)
    {
        string text = "Top Speed: " + stats.topSpeed + " m/s \n";
        text += "Current Speed: " + stats.speed + " m/s \n";
        text += "Current Heartrate: " + stats.heartrate + " BPM \n";
        text += "Distance Travelled: " + (int)stats.distanceTravelled + " m \n";
        text += "Time Elapsed: " + (int)stats.timeTravelled + " s";

        return text;
    }

    private void ShowResultScreen()
    {
        haltUpdate = true;

        PlayerStats stats = statsManager.Stats;

        recordContainer.SetActive(true);
        stateTextContainer.SetActive(false);

        endTopSpeed.text = stats.topSpeed + " m/s";
        endTopBPM.text = stats.topBPM + " BPM";
        endTimeTaken.text = stats.timeTravelled + " s";
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
