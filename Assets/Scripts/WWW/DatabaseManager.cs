using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DatabaseManager : MonoBehaviour
{
    private static DatabaseManager instance;

    [SerializeField] private string domain;
    [SerializeField] private string token;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than one DB Manager object!");
            Destroy(gameObject);
        }
    }

    public void AddPatient()
    {

    }

    public void AddReading(int userID, PlayerStats stats)
    {
        string data = "{ \"patients\":[{\"id\":2,\"readings\":[{\"BPM\":\"10\",\"date\":\"2017-08-16\"}]}]}";
        byte[] encodedData = System.Text.Encoding.UTF8.GetBytes(data);

        UnityWebRequest request = UnityWebRequest.Post(domain + "readings", data);

        
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
                instance = new DatabaseManager();

            return instance;
        }
    }

    public string Domain
    {
        get { return domain; }
        set { domain = value; }
    }
}
