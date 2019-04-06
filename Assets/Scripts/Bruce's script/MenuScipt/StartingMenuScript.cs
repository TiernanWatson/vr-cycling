using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StartingMenuScript : MonoBehaviour {

    public Button quickStartBtn;
    public Button customStartBtn;
    public Button recordMenuBtn;
    public Button quitGameBtn;
    public Button helpBtn;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void QuickStart()
    {
        Debug.Log("QuickStart init");
        SceneManager.LoadScene("DevMap");
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame init");
        Application.Quit();
    }

    public void ProcessVoiceCommand(string command)
    {
        Debug.Log("command passed into starting menu script");
        if (command.Contains("start"))
        {
            if(command.Contains("quick"))
            {
                quickStartBtn.onClick.Invoke();
            }else if(command.Contains("custom"))
            {
                customStartBtn.onClick.Invoke();
            }
        }else if(command.Contains("menu") && command.Contains("record"))
        {
            recordMenuBtn.onClick.Invoke();
        }else if(command.Contains("quit"))
        {
            quitGameBtn.onClick.Invoke();
        }else if(command.Contains("help"))
        {
            helpBtn.onClick.Invoke();
        }
    }
}