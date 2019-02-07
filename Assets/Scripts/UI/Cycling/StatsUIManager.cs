using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatsUIManager : MonoBehaviour
{
    private bool haltUpdate = false;

    [SerializeField]
    private StatsManager statsManager;

    [SerializeField]
    private GameObject stateTextContainer;
    [SerializeField]
    private Text statTextBox;

    [SerializeField]
    private GameObject recordContainer;
    [SerializeField]
    private Text endTopSpeed;
    [SerializeField]
    private Text endTopBPM;
    [SerializeField]
    private Text endTimeTaken;

	private void Start()
    {
        if (statsManager == null)
        {
            Debug.LogError("No StatsManager assigned in StatsUIManager.  Destroying object.");
            Destroy(this.gameObject);
            return;
        }

        DefaultActiveStates();

        GameState.Instance.CrossFinishEvent += UpdateRecordScreen;
	}

    private void DefaultActiveStates()
    {
        statTextBox.gameObject.SetActive(true);
        recordContainer.SetActive(false);
    }

    private void OnDisable()
    {
        GameState.Instance.CrossFinishEvent -= UpdateRecordScreen;
    }

    private void Update()
    {
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

    private void UpdateRecordScreen(bool isOn)
    {
        haltUpdate = !isOn;

        PlayerStats stats = statsManager.Stats;

        recordContainer.SetActive(isOn);
        stateTextContainer.SetActive(!isOn);

        endTopSpeed.text = stats.topSpeed + " m/s";
        endTopBPM.text = stats.topBPM + " BPM";
        endTimeTaken.text = stats.timeTravelled + " s";
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
