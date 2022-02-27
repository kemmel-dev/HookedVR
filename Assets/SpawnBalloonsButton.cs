using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SpawnBalloonsButton : MonoBehaviour
{

    public List<BalloonSpawner> balloonSpawners;

    public void SpawnBalloons()
    {
        foreach (BalloonSpawner balloonSpawner in balloonSpawners)
        {
            balloonSpawner.SpawnThreeRandomBalloons();
        }
    }
}
