using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class RecordMenuScript : MonoBehaviour {

    public PlayerStats playerStat;
    public Dropdown records;
    public string targetRecord;
    public Text distanceVal;
    public Text timeTakenVal;
    public Text averageSpeedVal;
    public Text greatestSpeedVal;
    public Text dateVal;
    public Text terrainVal;
    public Text weatherVal;
    public Text heartRateVal;

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
        List<string> recordOptions = new List<string> { };
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
        Debug.Log(hour.ToString() + " hour " + minute.ToString() + " minutes");
        return output;
    }

    public string getTerrain(int input)
    {
        if(input == 0)
        {
            return "Plain Road";
        }else if(input == 1)
        {
            return "Mountain";
        }else
        {
            return "City";
        }
    }

    public string getWeather(int input)
    {
        if (input == 0)
        {
            return "Sunny";
        }
        else if (input == 1)
        {
            return "Cloudy";
        }
        else if (input == 2)
        {
            return "Rainy";
        }
        else if (input == 3)
        {
            return "Windy";
        }else
        {
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
        terrainVal.text = getTerrain(playerStat.terrain);
        weatherVal.text = getWeather(playerStat.weather);
        heartRateVal.text = playerStat.heartrate.ToString() + " BPM";
    }
}
