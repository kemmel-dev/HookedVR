using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{

    public Transform target;

    public float speed;

    private void Start()
    {
        speed = Random.Range(5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);
    }
}
