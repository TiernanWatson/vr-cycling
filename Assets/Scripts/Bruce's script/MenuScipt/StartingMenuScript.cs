using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StartingMenuScript : MonoBehaviour
{
    [SerializeField] private Button quickStartBtn;
    [SerializeField] private Button customStartBtn;
    [SerializeField] private Button recordMenuBtn;
    [SerializeField] private Button quitGameBtn;
    [SerializeField] private Button helpBtn;
    public VoiceCommandReceiver voiceCommandReceiver;

    public void QuickStart()
    {
        SceneManager.LoadScene("DevMap");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ProcessVoiceCommand(string command)
    {
        if (command.Contains("start"))
        {
            if (command.Contains("quick"))
                quickStartBtn.onClick.Invoke();
            else if (command.Contains("custom"))
                voiceCommandReceiver.current = voiceCommandReceiver.customStartMenu;
                customStartBtn.onClick.Invoke();
        }
        else if(command.Contains("menu") && command.Contains("record"))
        {
            voiceCommandReceiver.current = voiceCommandReceiver.recordMenu;
            recordMenuBtn.onClick.Invoke();
        }
        else if(command.Contains("quit"))
        {
            quitGameBtn.onClick.Invoke();
        }
        else if(command.Contains("help"))
        {
            helpBtn.onClick.Invoke();
        }
    }
}