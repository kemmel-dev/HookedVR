using System;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public Transform spawnPos;
    public GameObject ballPrefab;

    internal void SpawnNewBall()
    {
        Instantiate(ballPrefab, spawnPos.position, Quaternion.identity);
    }
}