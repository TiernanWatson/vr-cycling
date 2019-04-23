using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DatabaseManager : MonoBehaviour
{
    private static DatabaseManager instance;

    // Domain that requests will communicate with
    [SerializeField] private string domain;

    // Bearer token used to access DB
    [SerializeField] private string token;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Allows DB to persist for use later
        }
        else
        {
            Debug.LogWarning("More than one DB Manager object!");
            Destroy(gameObject);
        }
    }

    public void AddPatient(int userID)
    {
        string data = "{\"patients\":[{\"Unique_ID\": " + userID + "}]}";

        UnityWebRequest request = CreateJSONRequest(domain + "patients", data);

        StartCoroutine(PostRequest(request));
    }

    public void AddReading(int userID, PlayerStats stats)
    {
        string data = "{ \"patients\":[{\"id\":\"" + userID + "\",\"readings\":[" + StatsToString(stats) + "]}]}";

        UnityWebRequest request = CreateJSONRequest(domain + "readings", data);

        StartCoroutine(PostRequest(request));
    }

    private UnityWebRequest CreateJSONRequest(string uri, string data)
    {
        UnityWebRequest request = new UnityWebRequest(uri, "POST");

        byte[] param = System.Text.Encoding.UTF8.GetBytes(data);

        request.uploadHandler = new UploadHandlerRaw(param);
        request.uploadHandler.contentType = "application/json";
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        return request;
    }

    private string StatsToString(PlayerStats stats)
    {
        // Formats with quotes which is necessary
        return "{\"BPM\":\"" + (int)stats.topBPM
            + "\",\"Speed\":\"" + (int)stats.topSpeed
            + "\",\"Distance\":\"" + (int)stats.distanceTravelled
            + "\",\"Time\":\"" + (int)stats.timeTravelled
            + "\",\"date\":\"" + System.DateTime.Now.ToString("yyyy-MM-dd")
            + "\"}";
    }

    IEnumerator PostRequest(UnityWebRequest request)
    {
        request.SetRequestHeader("Authorization", "Bearer " + token);

        yield return request.Send();

        if (request.isError)
        {
            Debug.Log("Error in network!");
        }
        else
        {
            Debug.Log("Request sent!");
            Debug.Log(request.downloadHandler.text);
        }
    }

    public static DatabaseManager Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("No DatabaseManager set up but called instance???");

            return instance;
        }
    }

    public string Domain
    {
        get { return domain; }
        set { domain = value; }
    }
}
