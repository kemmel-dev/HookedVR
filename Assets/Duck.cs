using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DuckZone"))
        {
            transform.parent.parent.GetComponent<Dobber>().duckAttached = false;
            GameObject.FindGameObjectWithTag("DuckCompletion").GetComponent<CompletionCounter>().IncrementScore();
            Destroy(transform.parent.gameObject);
        }
    }
}
