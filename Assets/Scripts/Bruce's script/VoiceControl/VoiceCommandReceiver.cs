using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceCommandReceiver : MonoBehaviour {

    public GameObject startingMenu;
    public StartingMenuScript startingMenuScript;
    public GameObject customStartMenu;
    public CustomMenuScript customMenuScript;
    public GameObject recordMenu;
    public RecordMenuScript recordMenuScript;
    public GameObject current;

    private Dictionary<string, System.Action> activityDictionary = new Dictionary<string, System.Action>();


    // Use this for initialization
    void Start () {
        // add specific actions for different menu
        AddMainMenuActions();

        // add utility actions
        activityDictionary.Add("help", CallHelpMenu);
        activityDictionary.Add("back", NavigateBack);
    }

    void AddMainMenuActions()
    {
        // adding links between keyword and actions
        activityDictionary.Add("quick start", NavigateQuickStart);
        activityDictionary.Add("custom start", NavigateCustomStart);
        activityDictionary.Add("record menu", NavigateRecord);
        
        activityDictionary.Add("quit", QuitGame);
    }

    void AddCustomMenuActions()
    {
        activityDictionary.Add("target by distance", customMenuScript.ToTargetByDistance);
        activityDictionary.Add("target by time", customMenuScript.ToTargetByTime);
        // TBD add further voice actions
    }

    public void NavigateToMenu(GameObject target)
    {
        current.SetActive(false);
        target.SetActive(true);
        current = target;
    }

    public void NavigateQuickStart()
    {
        startingMenuScript.QuickStart();
        Debug.Log("Voice control detected - quick start");
    }

    public void NavigateCustomStart()
    {
        NavigateToMenu(customStartMenu);
        Debug.Log("Voice control detected - custom start");
    }

    public void NavigateRecord()
    {
        NavigateToMenu(recordMenu);
        Debug.Log("Voice control detected - record menu");
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame init");
        Application.Quit();
    }

    public void NavigateBack()
    {
        if (current != startingMenu)
        {
            current.SetActive(false);
            startingMenu.SetActive(true);
            current = startingMenu;
        }
        else
        {
            Debug.Log("IGNORE: invalid access to back operation in starting menu");
        }
    }

    public void CallHelpMenu()
    {

    }

    void onActivityResult(string recognizedText)
    {
        string lower = recognizedText.ToLower();
        System.Action keywordAction;
        Debug.Log("Command: " + lower);
        if (activityDictionary.TryGetValue(lower, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
