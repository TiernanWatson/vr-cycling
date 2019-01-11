using UnityEngine;
using System.Collections;

public delegate void BinaryEvent(bool val);

public class GameState
{
    public event BinaryEvent CrossFinishEvent;

    private static GameState instance;

    private bool isPaused = false;
    private bool crossedFinish = false;

    public static GameState Instance
    {
        get {
            if (instance != null)
                return instance;

            instance = new GameState();
            return instance;
        }
    }

    public bool CrossedFinish
    {
        get { return crossedFinish; }
        set {
            crossedFinish = value;
            CrossFinishEvent.Invoke(value);
        }
    }
}
