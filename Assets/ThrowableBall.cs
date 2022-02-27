using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ThrowableBall : Throwable
{

    public BallSpawner ballSpawner;
    public ThrowCounter throwCounter;

    private bool firstTimeThrown = false;

    private void Start()
    {
        ballSpawner = GameObject.FindGameObjectWithTag("BallSpawner").GetComponent<BallSpawner>();
        throwCounter = GameObject.FindGameObjectWithTag("ThrowCounter").GetComponent<ThrowCounter>();
    }

    protected override void OnDetachedFromHand(Hand hand)
    {
        base.OnDetachedFromHand(hand);
        if (!firstTimeThrown)
        {
            firstTimeThrown = true;
            ballSpawner.SpawnBallWithDelay();
        }
        throwCounter.IncrementScore();
    }
}
