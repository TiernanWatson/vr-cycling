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

    void PassResultToCurrentMenu(string command)
    {
        if (current == startingMenu)
        {
            startingMenuScript.ProcessVoiceCommand(command);
        }
        else if(current == customStartMenu)
        {
            customMenuScript.ProcessVoiceCommand(command);
        }
        else if(current == recordMenu)
        {
            recordMenuScript.ProcessVoiceCommand(command);
        }else
        {
            Debug.Log("current state unknown!");
        }
    }

    void Start()
    {
        current = startingMenu;
    }

}
