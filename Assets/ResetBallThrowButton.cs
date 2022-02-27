using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ResetBallThrowButton : ResetButton
{

    public BallSpawner ballSpawner;
    public CompletionCounter completionCounter;
    public ThrowCounter throwCounter;

    public override void OnButtonDown(Hand fromHand)
    {
        base.OnButtonDown(fromHand);
        ballSpawner.RemoveSpawnedBalls();
        ballSpawner.SpawnBall();
        completionCounter.Reset();
        throwCounter.Reset();
    }

    public override void OnButtonUp(Hand fromHand)
    {
        base.OnButtonUp(fromHand);
    }

    public override void ColorSelf(Color newColor)
    {
    }
}
