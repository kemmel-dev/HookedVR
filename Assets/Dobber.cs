using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dobber : MonoBehaviour
{

    public bool duckAttached = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Duck") && !duckAttached)
        {
            duckAttached = true;
            other.transform.parent.parent.GetComponent<RotateAround>().enabled = false;
            other.transform.parent.parent.parent = this.transform;
        }
    }
}
