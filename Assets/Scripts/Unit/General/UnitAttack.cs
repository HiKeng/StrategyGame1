using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] float _attackInterval = 1f;
    bool _isAttackOnCooldown = false;

    UnitAreaToAttack _areaToAttack;

    void Awake()
    {
        _areaToAttack = GetComponent<UnitAreaToAttack>();
    }

    void Update()
    {
        
    }
}
