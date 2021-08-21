using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] int maxHit = 3;
    [SerializeField] Vector3 enemyHitBoxSize;

    [Header("VFX")]
    [SerializeField] GameObject vfx_enemyGetHit;
    [SerializeField] GameObject vfx_enemyDead;

    void Start()
    {
        BoxCollider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
        enemyCollider.size = enemyHitBoxSize;
    }

    void enemyGetHit(int damageTaken)
    {
        maxHit -= damageTaken;
        generateVFX(vfx_enemyGetHit);

        if(maxHit <= 0)
        {
            enemyDestoryed();
        }
    }

    private void enemyDestoryed()
    {
        generateVFX(vfx_enemyDead);
        Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        enemyGetHit(1);
    }

    void generateVFX(GameObject generateVFX)
    {
        GameObject vfxParent = GameObject.Find("Spawned_At_Runtime");

        GameObject newVFX = Instantiate(generateVFX, transform.position, Quaternion.identity);
        newVFX.transform.parent = vfxParent.transform;
    }

}
