﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

// TBD : load scene at ~ line 94 ------------------------------------ //

public class StartingMenuScript : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void QuickStart()
    {
        Debug.Log("QuickStart init");
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame init");
        Application.Quit();
    }
}