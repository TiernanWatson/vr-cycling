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

    void PassResultToCurrentMenu(string command)
    {
        if (current == startingMenu)
        {
            startingMenuScript.ProcessVoiceCommand(command);
        }
    }

    void Start()
    {
        current = startingMenu;
    }

}
