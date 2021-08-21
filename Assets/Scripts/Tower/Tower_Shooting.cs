using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Shooting : MonoBehaviour
{
    // Paramaters of each tower
    [Header("Attacking")]
    [SerializeField] float attackRange = 10f;
    [SerializeField] float shootingSpeed = 3f;
    [SerializeField] ParticleSystem vfx_Projectile;

    public Waypoint baseWaypoint; // Current tower tile position

    // State of each tower
    [Header("Target")]
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    [Header("Enemy List")]
    [SerializeField] List<Enemy> enemyInScene = new List<Enemy>();

    

    void Start()
    {
        vfx_Projectile.emissionRate = shootingSpeed;
    }
    void Update()
    {
        SetTargetEnemy();

        if(targetEnemy)
            FireAtEnemy();
        else
            Shoot(false);

    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<Enemy>();
        if(sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (Enemy testEnemy in sceneEnemies)
        {
            closestEnemy = GetCloset(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetCloset(Transform TransformA, Transform TransformB)
    {
        var distToA = Vector3.Distance(transform.position, TransformA.position);
        var distToB = Vector3.Distance(transform.position, TransformB.position);

        if(distToA < distToB)
        {
            return TransformA;
        }

        return TransformB;
    }

    void checkEnemyExists()
    {
        //GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

        var enemies = FindObjectsOfType<Enemy>();

        Debug.Log("Enemies = " + enemies);

        foreach(Enemy enemy in enemies)
        {
            enemyInScene.Add(enemy);
        }
    }

    void FireAtEnemy()
    {
            float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);

            if (distanceToEnemy <= attackRange)
                Shoot(true);
            else
                Shoot(false);
    }

    private void Shoot(bool isActive)
    {
        objectToPan.LookAt(targetEnemy);

        var emissionModule = vfx_Projectile.emission;
        emissionModule.enabled = isActive;
    }
}
