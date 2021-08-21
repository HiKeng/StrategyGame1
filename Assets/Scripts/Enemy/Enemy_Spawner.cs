using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    Pathfinder pathfinder;
    
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 4f;

    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Vector3 startingPoint;

    void Start()
    {
        StartCoroutine(RepeatedSpawnEnemies(secondsBetweenSpawns));
    }

    IEnumerator RepeatedSpawnEnemies(float WaitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(WaitTime);
            spawnEnemy();
        }
    }

    void spawnEnemy()
    {
        pathfinder = FindObjectOfType<Pathfinder>();
        startingPoint = pathfinder.startWaypoint.transform.position;

        GameObject enemy = Instantiate (enemyPrefab.gameObject, startingPoint, Quaternion.identity);
        enemy.transform.parent = transform;
    }
}
