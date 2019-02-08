using UnityEngine;
using System.Collections;

public class PlayerOnOff : MonoBehaviour
{
	private void OnEnable()
    {
        GameController.Instance.CrossFinishLine += DisablePlayer;
	}

    private void OnDisable()
    {
        GameController.Instance.CrossFinishLine -= DisablePlayer;
    }

    private void DisablePlayer()
    {
        GetComponent<VZPlayer>().enabled = false;
    }
}
