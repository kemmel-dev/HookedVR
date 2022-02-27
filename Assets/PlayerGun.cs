using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerGun : Interactable
{

    // a reference to the action
    public SteamVR_Action_Boolean fireGun;
    public SteamVR_Action_Boolean grabGun;
    // a reference to the hand
    public SteamVR_Input_Sources handType;

    public Vector3 GunDir
    {
        get
        {
            return leftHand.position - rightHand.position;
        }
    }

    public Collider gunCollider;

    public Transform leftHand, rightHand, bulletOrigin;
    public GameObject bulletPrefab;
    public float fireSpeed;

    public bool attached = false;
    public bool hovering = false;

    void Start()
    {
        fireGun.AddOnStateDownListener(TriggerDown, handType);
        grabGun.AddOnStateDownListener(GrabGun, handType);
    }

    protected override void OnHandHoverBegin(Hand hand)
    {
        base.OnHandHoverBegin(hand);
        hovering = true;
    }

    protected override void OnHandHoverEnd(Hand hand)
    {
        base.OnHandHoverEnd(hand);
        hovering = false;
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (attached)
            Fire();
    }

    public void GrabGun(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (hovering)
        {
            attached = true;
            gunCollider.enabled = false;
            return;
        }
        if (attached)
        {
            attached = false;
            gunCollider.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (attached)
        {
            if (leftHand != null && rightHand != null)
            {
                transform.position = (leftHand.position + rightHand.position) / 2;
                transform.LookAt(transform.position + GunDir * 5);
            }
        }
    }

    public void Fire()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletOrigin.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.GetComponent<Rigidbody>().velocity = GunDir * fireSpeed;
    }

}

