using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ThrowableBall : Throwable
{

    public BallSpawner ballSpawner;

    protected override void OnAttachedToHand(Hand hand)
    {
        base.OnAttachedToHand(hand);

        ballSpawner.SpawnNewBall();
    }
}
