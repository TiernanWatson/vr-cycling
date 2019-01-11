using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecordMenuScript : MonoBehaviour {

    public Dropdown records;
    public Text distanceVal;
    public Text timeTakenVal;
    public Text averageSpeedVal;
    public Text greatestSpeedVal;
    public Text dateVal;
    public Text terrainVal;
    public Text weatherVal;
    public Text heartRateVal;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void UpdateRecord()
    {
        distanceVal.text = "";
        timeTakenVal.text = "";
        averageSpeedVal.text = "";
        greatestSpeedVal.text = "";
        dateVal.text = "";
        terrainVal.text = "";
        weatherVal.text = "";
        heartRateVal.text = "";
    }
}
