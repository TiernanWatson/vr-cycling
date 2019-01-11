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
        records.ClearOptions();
        List<string> dropDownOptions = new List<string> { };
        for (int i = 0; i < PlayerPrefs.GetInt("workoutNo"); i++)
        {
            dropDownOptions.Add("Work Out " + (i+1));
        }
        records.AddOptions(dropDownOptions);

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

    public void UpdateRecord()
    {

        targetRecord = "workout" + (records.value+1) + ".json";
        playerStat = PlayerStats.LoadFromJSONFile(targetRecord);
        distanceVal.text = playerStat.distanceTravelled.ToString() + " km";
        timeTakenVal.text = ToHoursAndMinutes(playerStat.timeTravelled);
        averageSpeedVal.text = playerStat.speed.ToString() + " km / hr";
        greatestSpeedVal.text = playerStat.topSpeed.ToString() + " km / hr";
        dateVal.text = "";
        terrainVal.text = "";
        weatherVal.text = "";
        heartRateVal.text = playerStat.heartrate.ToString() + " BPM";
    }
}
