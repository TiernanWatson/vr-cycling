using UnityEngine;
using System.IO;

[System.Serializable]
public class PlayerStats
{
    public float topSpeed = 0f;
    public float topBPM = 0f;
    public float distanceTravelled = 0f;
    public float timeTravelled = 0f;

    // These are not useful to be saved
    [System.NonSerialized]
    public float speed = 0f;
    [System.NonSerialized]
    public float heartrate = 0f;

    public static PlayerStats LoadFromJSONFile(string fileName)
    {
        fileName = Path.Combine(Application.streamingAssetsPath, fileName);

        string jsonText = File.ReadAllText(fileName);

        return JsonUtility.FromJson<PlayerStats>(jsonText);
    }

    public static void OverwriteFromJSONFile(string fileName, ref PlayerStats stats)
    {
        fileName = Path.Combine(Application.streamingAssetsPath, fileName);

        string jsonText = File.ReadAllText(fileName);

        JsonUtility.FromJsonOverwrite(jsonText, stats);
    }

    public static void SaveToJSONFile(string fileName, PlayerStats stats)
    {
        string objAsJson = JsonUtility.ToJson(stats);

        fileName = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(fileName))
            Debug.LogWarning("File: " + fileName + " already exists.  Overwriting.");

        File.WriteAllText(fileName, objAsJson);
    }
}
