using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

// --- Player pref value:
// (int) primaryUnit (0...99)
// (int) secondaryUnit (0...99)
// (int) weatherChoice (0 sunny, 1 cloudy, 2 rainy, 3 windy, 4 misty)
// (int) terrainChoice (0 plain road, 1 mountain, 2 city)
// (string) workOutTarget (time/distance)

// press start and values will be record
// press back and page will be reset
// press target method will change text and placeholder


public class CustomMenuScript : MonoBehaviour
{
    [SerializeField] private string workOutTarget = "time";

    [SerializeField] private Button targetBtn;
    [SerializeField] private Button startBtn;
    [SerializeField] private Button backBtn;
    [SerializeField] private Button helpBtn;
    [SerializeField] private InputField primaryField;
    [SerializeField] private InputField secondaryField;
    [SerializeField] private Dropdown weatherDropDown;
    [SerializeField] private Dropdown terrainDropDown;
    public VoiceCommandReceiver voiceCommandReceiver;

    private void ResetVariable()
    {
        ToTargetByTime();
        weatherDropDown.value = 0;
        terrainDropDown.value = 0;
        ResetInputField();
    }

    private void ResetInputField()
    {
        primaryField.text = "";
        secondaryField.text = "";
    }

    public void ToTargetByTime()
    {
        workOutTarget = "time";

        targetBtn.GetComponentInChildren<Text>().text = "Target By Time";
        primaryField.placeholder.GetComponent<Text>().text = "Hour(s)";
        secondaryField.placeholder.GetComponent<Text>().text = "Minute(s)";
    }

    public void ToTargetByDistance()
    {
        workOutTarget = "distance";

        targetBtn.GetComponentInChildren<Text>().text = "Target By Distance";
        primaryField.placeholder.GetComponent<Text>().text = "km";
        secondaryField.placeholder.GetComponent<Text>().text = "m";
    }

    public void SwitchTargetButtonPressed()
    {
        if (workOutTarget.Equals("time"))
        {
            ResetInputField();
            ToTargetByDistance();
        }
        else if (workOutTarget.Equals("distance"))
        {
            ResetInputField();
            ToTargetByTime();
        }
    }

    private bool StoreChoices()
    {
        if (string.IsNullOrEmpty(secondaryField.text))
        {
            FindObjectOfType<DialogueTrigger>().TriggerErrorMessage();
            return false;
        }
        else
        {
            if(string.IsNullOrEmpty(primaryField.text))
            {
                PlayerPrefs.SetInt("primaryUnit", 0);
            }
            else
            {
                PlayerPrefs.SetInt("primaryUnit", int.Parse(primaryField.text));
            }

            PlayerPrefs.SetInt("secondaryUnit", int.Parse(secondaryField.text));
            PlayerPrefs.SetInt("weatherChoice", weatherDropDown.value);
            PlayerPrefs.SetInt("terrainChoice", terrainDropDown.value);
            PlayerPrefs.SetString("workOutTarget", workOutTarget);

            PlayerPrefs.Save();

            return true;
        }

    }

    public void StartButtonPressed()
    {
        if (StoreChoices())
        {
            FindObjectOfType<DialogueManager>().EndDialogue();

            string mapToLoad = PlayerPrefs.GetInt("terrainChoice") == 0
                ? "DevMap" : "DirtTrack";

            SceneManager.LoadScene(mapToLoad);
        }
    }

    public void ProcessVoiceCommand(string command)
    {
        if (command.Contains("start"))
        {
            voiceCommandReceiver.current = voiceCommandReceiver.startingMenu;
            startBtn.onClick.Invoke();
        }
        else if (command.Contains("switch"))
        {
            targetBtn.onClick.Invoke();
        }
        else if (command.Contains("back"))
        {
            voiceCommandReceiver.current = voiceCommandReceiver.startingMenu;
            backBtn.onClick.Invoke();
        }
        else if (command.Contains("help"))
        {
            helpBtn.onClick.Invoke();
        }
    }

}