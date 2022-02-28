using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hengel : MonoBehaviour
{

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    public void Unfreeze()
    {
        rb.constraints = RigidbodyConstraints.None;
    }

    public void Freeze()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
