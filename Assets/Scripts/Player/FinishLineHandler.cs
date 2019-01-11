using UnityEngine;
using System.Collections;

public class FinishLineHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        GameState.Instance.CrossedFinish = true;
    }
}
