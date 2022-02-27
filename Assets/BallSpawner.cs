using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public float spawnDelay;
    public Transform spawnPos;
    public GameObject ballPrefab;

    public List<GameObject> spawnedBalls;

    private void Start()
    {
        SpawnBall();
    }

    public void SpawnBallWithDelay()
    {
        StartCoroutine(SpawnBallWithDelay(spawnDelay));
    }

    private IEnumerator SpawnBallWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnBall();
    }

    public void SpawnBall()
    {
        spawnedBalls.Add(Instantiate(ballPrefab, spawnPos.position, Quaternion.identity));
    }

    public void RemoveSpawnedBalls()
    {
        foreach (GameObject ball in spawnedBalls)
        {
            Destroy(ball);
        }
    }
}