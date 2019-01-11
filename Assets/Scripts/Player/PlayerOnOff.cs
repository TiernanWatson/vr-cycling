using UnityEngine;
using System.Collections;

public class PlayerOnOff : MonoBehaviour
{
	private void Start()
    {
        GameState.Instance.CrossFinishEvent += ChangeState;
	}

    private void OnDisable()
    {
        GameState.Instance.CrossFinishEvent -= ChangeState;
    }

    private void ChangeState(bool state)
    {
        GetComponent<VZPlayer>().enabled = !state;
    }
}
