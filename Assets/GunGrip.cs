using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GunGrip : Throwable
{

    public PlayerGun playerGun;
    public bool left;

    protected override void OnAttachedToHand(Hand hand)
    {
        base.OnAttachedToHand(hand);
        if (left) playerGun.leftHand = hand.transform;
        else playerGun.rightHand = hand.transform;
    }

    protected override void OnDetachedFromHand(Hand hand)
    {
        base.OnDetachedFromHand(hand);
        if (left) playerGun.leftHand = null;
        else playerGun.rightHand = null;
    }

}
