using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanTrigger : MonoBehaviour
{

    public CompletionCounter completionCounter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Can"))
        {
            completionCounter.IncrementScore(1);
        }
    }
}
