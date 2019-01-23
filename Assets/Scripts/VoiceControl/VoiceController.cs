using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceController : MonoBehaviour
{

    public GameObject startingMenu;
    public GameObject customStartMenu;
    public GameObject recordMenu;
    public GameObject resultMenu;
    public GameObject current;

    // Voice command vars
    private Dictionary<string, System.Action> keyActs = new Dictionary<string, System.Action>();
    private KeywordRecognizer recognizer;

    //Vars needed for sound playback.
    private AudioSource soundSource;
    public AudioClip[] sounds;

    // Use this for initialization
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        // add specific actions for different menu
        AddMainMenuActions();
        // add utility actions
        keyActs.Add("help", CallHelpMenu);
        keyActs.Add("back", NavigateBack);
        recognizer = new KeywordRecognizer(keyActs.Keys.ToArray());
        recognizer.OnPhraseRecognized += OnKeywordsRecognized;
        recognizer.Start();
    }

    void AddMainMenuActions()
    {
        // adding links between keyword and actions
        keyActs.Add("quick start", NavigateQuickStart);
        keyActs.Add("custom start", NavigateCustomStart);
        keyActs.Add("record menu", NavigateRecordMenu);
        keyActs.Add("quit", NavigateQuit);
    }

    void AddCustomMenuActions()
    {
        //keyActs.Add("target by distance", TargetToDistance);
        //keyActs.Add("target by time", TargetToTime);

    }

    public void NavigateQuickStart()
    {

    }

    public void NavigateCustomStart()
    {

    }

    public void NavigateRecordMenu()
    {

    }

    public void NavigateQuit()
    {

    }

    public void CallHelpMenu()
    {

    }

    public void NavigateBack()
    {

    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Command: " + args.text);
        keyActs[args.text].Invoke();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
