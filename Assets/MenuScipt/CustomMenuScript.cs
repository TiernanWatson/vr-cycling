using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class CustomMenuScript : MonoBehaviour {

    bool selectByTime = true;
    bool selectByDistance = false;
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

    public void ResetVariable()
    {
        selectByTime = true;
        selectByDistance = false;
        targetButton.GetComponentInChildren<Text>().text = "Target By Time";
        primaryField.placeholder.GetComponent<Text>().text = "Hour(s)";
        secondaryField.placeholder.GetComponent<Text>().text = "Minute(s)";
        weatherDropDown.value = 0;
        terrainDropDown.value = 0;
    }

    private void ToTargetByTime()
    {
        this.selectByTime = true;
        this.selectByDistance = false;
        targetButton.GetComponentInChildren<Text>().text = "Target By Time";
        primaryField.placeholder.GetComponent<Text>().text = "Hour(s)";
        secondaryField.placeholder.GetComponent<Text>().text = "Minute(s)";
        Debug.Log("switch from target by distance to target by time");
    }

    private void ToTargetByDistance()
    {
        this.selectByTime = false;
        this.selectByDistance = true;
        targetButton.GetComponentInChildren<Text>().text = "Target By Distance";
        primaryField.placeholder.GetComponent<Text>().text = "km";
        secondaryField.placeholder.GetComponent<Text>().text = "m";
        Debug.Log("switch from target by time to target by distance");
    }

    public void SwitchTargetButtonPressed()
    {
        if (selectByTime)
        {
            ToTargetByDistance();
        }else
        {
            ToTargetByTime();
        }
    }

    public void StartButtonPressed()
    {
        Debug.Log("CustomStart init");
        if (selectByDistance)
        {
            // return km and m
        }
        else
        {
            // return hour and minute
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}