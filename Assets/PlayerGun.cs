using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerGun : MonoBehaviour
{

    // a reference to the action
    public SteamVR_Action_Boolean SphereOnOff;
    // a reference to the hand
    public SteamVR_Input_Sources handType;

    public Vector3 GunDir
    {
        get
        {
            return leftHand.position - rightHand.position;
        }
    }
    public Transform leftHand, rightHand, bulletOrigin;
    public GameObject bulletPrefab;
    public float fireSpeed;

    void Start()
    {
        SphereOnOff.AddOnStateDownListener(TriggerDown, handType);
        SphereOnOff.AddOnStateUpListener(TriggerUp, handType);
    }
    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("trigger down");
        Fire();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (leftHand.position + rightHand.position) / 2;
        transform.LookAt(transform.position + GunDir * 5);
    }

    public void Fire()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletOrigin.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.GetComponent<Rigidbody>().velocity = GunDir * fireSpeed;
    }

}

