using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class VoiceCommandManager : MonoBehaviour {

    public Text myText;
    public Button voiceCommandTrigger;
    AndroidJavaClass unityClass;
    AndroidJavaObject unityActivity;
    AndroidJavaObject unityContext;
    AndroidJavaObject pluginClass;

    /*  
     *  add listener to button for triggering the function
     *  set up the unity activity, context in order to pass into the Java Files for verification 
    */
    void Start()
    {
        voiceCommandTrigger.onClick.AddListener(StartSpeechToTextProcess);
        unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        unityContext = unityActivity.Call<AndroidJavaObject>("getApplicationContext");
        StartSpeechToTextProcess();
    }


    // 
    void StartSpeechToTextProcess()
    {
        AndroidJavaClass unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject unityContext = unityActivity.Call<AndroidJavaObject>("getApplicationContext");
        unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(runOnUiThread)); // for functions that need to run on main thread
    }

    void runOnUiThread()
    {
        Debug.Log("Plugin Class initialize");
        pluginClass = new AndroidJavaObject("com.example.speechtotextplugin.SpeechToText");

        //Debug.Log("Request Audio Permission");
        //pluginClass.Call("requestAudioPermissions", unityContext, unityActivity);

        Debug.Log("Speech Recognizer initialize");
        pluginClass.Call("InitializeSpeechRecognizer", unityContext);

        Debug.Log("Speech to text process started");
        pluginClass.Call("StartSpeechToTextPlugin");
    }

    void ProcessResult(string result)
    {
        myText.text = result;
    }
}
