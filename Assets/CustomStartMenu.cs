using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomStartMenu : MonoBehaviour {

    public int weatherOption = 1;
    public int plainOption = 1;
    bool selectByTime = false;
    bool selectByDistance = true;
    public InputField primaryField;
    public InputField secondaryField;
    public TextMeshProUGUI primaryUnit;
    public TextMeshProUGUI secondaryUnit;
    public int km = 0;
    public int m = 0;
    public int hours = 0;
    public int minutes = 0;


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToTargetByTime()
    {
        this.selectByDistance = false;
        this.selectByTime = true;
        primaryUnit.text = "hour";
        secondaryUnit.text = "minute";
        primaryField.placeholder.GetComponent<Text>().text = "Enter hour";
        secondaryField.placeholder.GetComponent<Text>().text = "Enter minute";
        Debug.Log("switch from target by distance to target by time");
    }

    public void ToTargetByDistance()
    {
        this.selectByTime = false;
        this.selectByDistance = true;
        primaryUnit.text = "km";
        secondaryUnit.text = "m";
        primaryField.placeholder.GetComponent<Text>().text = "Enter km";
        secondaryField.placeholder.GetComponent<Text>().text = "Enter m";
        Debug.Log("switch from target by time to target by distance");
    }

    public void StartButtonPressed()
    {
        if (selectByDistance)
        {
            // return km and m
        }
        else
        {
            // return hour and minute
        }
    }
}
