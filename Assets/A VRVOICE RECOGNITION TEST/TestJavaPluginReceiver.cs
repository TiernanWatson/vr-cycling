﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestJavaPluginReceiver : MonoBehaviour {

    public Text myText;
    public Button voiceCommandTrigger;
    AndroidJavaClass unityClass;
    AndroidJavaObject unityActivity;
    AndroidJavaObject unityContext;
    AndroidJavaObject pluginClass;


    // Use this for initialization
    void Start () {
        voiceCommandTrigger.onClick.AddListener(StartSpeechToTextProcess);
        unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        unityContext = unityActivity.Call<AndroidJavaObject>("getApplicationContext");
    }

    // Update is called once per frame
    void Update () {
	}

    void StartSpeechToTextProcess()
    {
        AndroidJavaClass unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject unityContext = unityActivity.Call<AndroidJavaObject>("getApplicationContext");

        unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(runOnUiThread));
    }

    void runOnUiThread()
    {
        Debug.Log("Plugin Class initialize");
        pluginClass = new AndroidJavaObject("com.example.speechtotextplugin.SpeechToText");

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