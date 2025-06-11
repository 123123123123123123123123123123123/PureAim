using UnityEngine;
using System.Collections.Generic;

public class TargetManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public int maxTargets = 3;
    public Vector3 spawnAreaSize = new Vector3(10f, 5f, 10f);

    private List<GameObject> activeBalls = new List<GameObject>();



    void Start()
    {
        for (int i = 0; i < maxTargets; i++)
        {
            SpawnBall();
        }
    }

    public void BallDestroyed(GameObject ball)
    {
        activeBalls.Remove(ball);
        SpawnBall();

    }

    void SpawnBall()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        Vector3 spawnPos = transform.position + randomPosition;
        GameObject newBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity);
        activeBalls.Add(newBall);

        // Assign the manager to the ball
        TargetBall targetScript = newBall.GetComponent<TargetBall>();
        targetScript.manager = this;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
