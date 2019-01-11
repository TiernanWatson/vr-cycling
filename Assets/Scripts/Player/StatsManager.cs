using UnityEngine;
using System.Collections;

public class StatsManager : MonoBehaviour
{
    private int localWorkoutNo = 0;

    private PlayerStats playerStats;

    private void Start()
    {
        localWorkoutNo = PlayerPrefs.GetInt("workoutNo");
        playerStats = new PlayerStats();
    }

    private void Update()
    {
        playerStats.distanceTravelled = (int)VZPlayer.Controller.Distance;

        // The following only works when bike is connected (not keyboard control)
        if (!VZPlayer.Controller.IsBikeConnected())
            return;

        playerStats.heartrate = VZPlayer.Controller.HeartRate();

        if (playerStats.heartrate > playerStats.topBPM)
            playerStats.topBPM = playerStats.heartrate;

        playerStats.speed = VZPlayer.Controller.InputSpeed;

        if (playerStats.topSpeed < playerStats.speed)
            playerStats.topSpeed = playerStats.speed;
    }

    private void OnDisable()
    {
        localWorkoutNo++;

        PlayerStats.SaveToJSONFile("workout" + localWorkoutNo + ".json", playerStats);

        PlayerPrefs.SetInt("workoutNo", localWorkoutNo);
        PlayerPrefs.Save();
    }

    public PlayerStats Stats
    {
        get { return playerStats; }
    }
}
