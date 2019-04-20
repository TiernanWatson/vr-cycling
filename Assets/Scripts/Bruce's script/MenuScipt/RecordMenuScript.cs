using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class RecordMenuScript : MonoBehaviour {

    [SerializeField] private PlayerStats playerStat;
    [SerializeField] private Dropdown records;
    [SerializeField] private string targetRecord;
    [SerializeField] private Text distanceVal;
    [SerializeField] private Text timeTakenVal;
    [SerializeField] private Text averageSpeedVal;
    [SerializeField] private Text greatestSpeedVal;
    [SerializeField] private Text dateVal;
    [SerializeField] private Text terrainVal;
    [SerializeField] private Text weatherVal;
    [SerializeField] private Text heartRateVal;
    [SerializeField] private Button backBtn;
    [SerializeField] private Button helpBtn;

    void Start()
    {
        DropDownOptionUpdate();
        UpdateRecord();
    }

    public void ResetVariable()
    {
        records.value = 0;
    }

    public void DropDownOptionUpdate()
    {
        List<string> recordOptions = new List<string>();

        for(int i = 0; i < PlayerPrefs.GetInt("workoutNo"); i++)
        {
            recordOptions.Add("Work Out " + (i + 1));
        }

        records.ClearOptions();
        records.AddOptions(recordOptions);
    }


    public string ToHoursAndMinutes(float input)
    {
        int inputInt = (int)input;
        int hour = inputInt / 60;
        int minute = inputInt % 60;

        string output = hour.ToString() + " hour " + minute.ToString() + " minutes";
        
        return output;
    }

    public string GetTerrain(int input)
    {
        switch (input)
        {
            case 0:
                return "Plain Road";
            case 1:
                return "Mountain";
            default:
                return "City";
        }
    }

    public string GetWeather(int input)
    {
        switch (input)
        {
            case 0:
                return "Sunny";
            case 1:
                return "Cloudy";
            case 2:
                return "Rainy";
            case 3:
                return "Windy";
            default:
                return "Misty";
        }
    }

    public void UpdateRecord()
    {

        targetRecord = "workout" + (records.value+1) + ".json";
        playerStat = PlayerStats.LoadFromJSONFile(targetRecord);
        distanceVal.text = playerStat.distanceTravelled.ToString() + " km";
        timeTakenVal.text = ToHoursAndMinutes(playerStat.timeTravelled);
        averageSpeedVal.text = playerStat.speed.ToString() + " km / hr";
        greatestSpeedVal.text = playerStat.topSpeed.ToString() + " km / hr";
        dateVal.text = playerStat.date;
        terrainVal.text = GetTerrain(playerStat.terrain);
        weatherVal.text = GetWeather(playerStat.weather);
        heartRateVal.text = playerStat.heartrate.ToString() + " BPM";
    }

    public void ProcessVoiceCommand(string command)
    {
        if (command.Contains("back"))
        {
            backBtn.onClick.Invoke();
        }
        else if (command.Contains("help"))
        {
            helpBtn.onClick.Invoke();
        }
    }
}
