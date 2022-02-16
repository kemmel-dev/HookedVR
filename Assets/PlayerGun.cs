using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{

    public Transform leftHand, rightHand;

    // Update is called once per frame
    void Update()
    {

        Vector3 gunDir = rightHand.position - leftHand.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, gunDir);
        transform.position = (leftHand.position + rightHand.position) / 2;
    }
}

