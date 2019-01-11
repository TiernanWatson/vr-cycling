using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsUIManager : MonoBehaviour
{
    [SerializeField]
    private StatsManager statsManager;

    [SerializeField]
    private Text statTextBox;

	private void Start()
    {
        if (statsManager == null)
        {
            Debug.LogError("No StatsManager assigned in StatsUIManager.  Destroying object.");

            Destroy(this.gameObject);
        }
	}
	
	private void Update()
    {
        statTextBox.text = StatsToText(statsManager.Stats);
	}

    private string StatsToText(PlayerStats stats)
    {
        string text = "Top Speed: " + stats.topSpeed + "m/s \n";
        text += "Current Speed: " + stats.speed + "m/s \n";
        text += "Current Heartrate: " + stats.heartrate + "BPM \n";
        text += "Distance Travelled: " + stats.distanceTravelled + "m \n";
        text += "Time Elapsed: " + stats.timeTravelled + "s";

        return text;
    }
}
