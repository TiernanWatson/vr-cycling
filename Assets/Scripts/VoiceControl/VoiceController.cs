using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;
//using UnityEngine.Windows.Speech;

public class VoiceController : MonoBehaviour
{
    // linking all menu object + menu script to access methods
   /* public GameObject startingMenu;
    public StartingMenuScript startingMenuScript;
    public GameObject customStartMenu;
    public CustomMenuScript customMenuScript;
    public GameObject recordMenu;
    public RecordMenuScript recordMenuScript;
    public GameObject resultMenu;
    public ResultMenuScript resultMenuScript;
    public GameObject current;

    // Voice command variables
    private Dictionary<string, System.Action> keyActs = new Dictionary<string, System.Action>();
    private KeywordRecognizer recognizer;

    //Variables for sound playback.
    private AudioSource soundSource;
    public AudioClip[] sounds;

    // Use this for initialization
    void Start()
    {
        // initialise soundSource
        soundSource = GetComponent<AudioSource>();
        // add specific actions for different menu
        AddMainMenuActions();
        // add utility actions
        keyActs.Add("help", CallHelpMenu);
        keyActs.Add("back", NavigateBack);
        // initialise recognizer and start it
        recognizer = new KeywordRecognizer(keyActs.Keys.ToArray());
        recognizer.OnPhraseRecognized += OnKeywordsRecognized;
        recognizer.Start();
    }

    void AddMainMenuActions()
    {
        // adding links between keyword and actions
        keyActs.Add("quick start", NavigateQuickStart);
        keyActs.Add("custom start", NavigateCustomStart);
        keyActs.Add("record menu", NavigateRecord);
        keyActs.Add("quit", QuitGame);
    }

    void AddCustomMenuActions()
    {
        keyActs.Add("target by distance", customMenuScript.ToTargetByDistance);
        keyActs.Add("target by time", customMenuScript.ToTargetByTime);
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

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        Debug.Log("Command: " + args.text);
        if (keyActs.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }*/
}
