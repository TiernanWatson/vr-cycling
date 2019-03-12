using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

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
        SceneManager.LoadScene("DevMap");
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame init");
        Application.Quit();
    }
}