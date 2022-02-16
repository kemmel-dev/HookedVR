using System;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public Transform spawnPos;
    public GameObject ballPrefab;

    private void Start()
    {
        SpawnNewBall();
    }

    internal void SpawnNewBall()
    {
        Instantiate(ballPrefab, spawnPos.position, Quaternion.identity);
    }
}