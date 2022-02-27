using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BallThrow : MonoBehaviour
{
    public BalloonSpawner balloonSpawner;
    public ThrowCounter throwCounter;


    public void OnCompletion()
    {
        balloonSpawner.SpawnThreeRandomBalloons();
        Debug.Log("updating highscore" + throwCounter.HighScore);
        throwCounter.UpdateHighScore();
        Debug.Log("updated highscore" + throwCounter.HighScore);
    }
}
