using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserIDMenu : MonoBehaviour
{
    [SerializeField] private InputField textField;

    public void ClickGo()
    {
        int id;
        if(!int.TryParse(textField.text, out id))
            return;

        DatabaseManager.Instance.AddPatient(id);

        PlayerPrefs.SetInt("uID", id);
        PlayerPrefs.Save();
    }
}
