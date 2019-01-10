using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

// TBD : load scene at ~ line 94 ------------------------------------ //

// --- Player pref value:
// (int) primaryUnit (0...99)
// (int) secondaryUnit (0...99)
// (int) weatherChoice (0 sunny, 1 cloudy, 2 rainy, 3 windy, 4 misty)
// (int) terrainChoice (0 plain road, 1 mountain, 2 city)
// (string) workOutTarget (time/distance)

// press start and values will be record
// press back and page will be reset
// press target method will change text and placeholder


public class CustomMenuScript : MonoBehaviour {

    public string workOutTarget = "time";
    public Button targetButton;
    public InputField primaryField;
    public InputField secondaryField;
    public Dropdown weatherDropDown;
    public Dropdown terrainDropDown;


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ResetVariable()
    {
        ToTargetByTime();
        weatherDropDown.value = 0;
        terrainDropDown.value = 0;
        ResetInputField();
        Debug.Log("variable reset");
    }

    private void ResetInputField()
    {
        primaryField.text = "";
        secondaryField.text = "";
    }

    private void ToTargetByTime()
    {
        workOutTarget = "time";
        targetButton.GetComponentInChildren<Text>().text = "Target By Time";
        primaryField.placeholder.GetComponent<Text>().text = "Hour(s)";
        secondaryField.placeholder.GetComponent<Text>().text = "Minute(s)";
        Debug.Log("switch to target by time");
    }

    private void ToTargetByDistance()
    {
        workOutTarget = "distance";
        targetButton.GetComponentInChildren<Text>().text = "Target By Distance";
        primaryField.placeholder.GetComponent<Text>().text = "km";
        secondaryField.placeholder.GetComponent<Text>().text = "m";
        Debug.Log("switch to target by distance");
    }

    public void SwitchTargetButtonPressed()
    {
        if (workOutTarget == "time")
        {
            ResetInputField();
            ToTargetByDistance();
        }else if(workOutTarget == "distance")
        {
            ResetInputField();
            ToTargetByTime();
        }
    }

    private void storeChoices()
    {
        Debug.Log("CustomStart init");
        if (primaryField.text == "" || secondaryField.text == "")
        {
            Debug.Log("please enter value in input field");
        }else
        {
            PlayerPrefs.SetInt("primaryUnit", int.Parse(primaryField.text));
            Debug.Log("primary unit set to " + PlayerPrefs.GetInt("primaryUnit"));
            PlayerPrefs.SetInt("secondaryUnit", int.Parse(secondaryField.text));
            Debug.Log("secondary unit set to " + PlayerPrefs.GetInt("secondaryUnit"));
            PlayerPrefs.SetInt("weatherChoice", weatherDropDown.value);
            Debug.Log("weather choice set to " + PlayerPrefs.GetInt("weatherChoice"));
            PlayerPrefs.SetInt("terrainChoice", terrainDropDown.value);
            Debug.Log("terrain choice set to " + PlayerPrefs.GetInt("terrainChoice"));
            PlayerPrefs.SetString("workOutTarget", workOutTarget);
            Debug.Log("work out target set to " + PlayerPrefs.GetString("workOutTarget"));
        }
        
    }

    public void StartButtonPressed()
    {
        storeChoices();
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}