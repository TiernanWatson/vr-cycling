using System;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    private int localWorkoutNo;
    private float startTime;

    private PlayerStats playerStats;

    private void Start()
    {
        localWorkoutNo = PlayerPrefs.GetInt("workoutNo");
        startTime = Time.time;

        playerStats = new PlayerStats
        {
            terrain = PlayerPrefs.GetInt("terrainChoice"),
            weather = PlayerPrefs.GetInt("weatherChoice"),
            workoutTarget = PlayerPrefs.GetString("workoutTarget"),
            date = DateTime.Now.ToString("dd/MM/yyyy")
        };
    }

    private void Update()
    {
        playerStats.timeTravelled = Time.time - startTime;

        playerStats.distanceTravelled = VZPlayer.Controller.Distance;

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
