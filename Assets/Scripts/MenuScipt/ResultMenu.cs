﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultMenu : MonoBehaviour
{
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
        UpdateRecord();
    }

    void UpdateRecord()
    {
        distanceVal.text = "";
        timeTakenVal.text = "";
        averageSpeedVal.text = "";
        greatestSpeedVal.text = "";
        dateVal.text = "";
        terrainVal.text = "";
        weatherVal.text = "";
        heartRateVal.text = "";
    }
}
