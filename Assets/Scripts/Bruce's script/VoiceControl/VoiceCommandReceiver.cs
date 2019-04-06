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
    public Text myText;

    private Dictionary<string, System.Action> activityDictionary = new Dictionary<string, System.Action>();

    void PassResultToCurrentMenu(string command)
    {
        myText.text = command;
        if (current == startingMenu)
        {
            Debug.Log("current in starting menu");
            startingMenuScript.ProcessVoiceCommand(command);
        }
    }

    // Use this for initialization
    void Start () {
        current = startingMenu;
    }


    // Update is called once per frame
    void Update () {
	
	}
}
