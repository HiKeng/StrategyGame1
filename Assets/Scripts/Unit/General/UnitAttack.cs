﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] UnitAreaToAttack _areaToAttack;

    [SerializeField] float _attackCooldownTime = 20f;
    [SerializeField] float _damagePerHit = 20f;
    bool _isAttackOnCooldown = false;

    [Header("Events")]
    [SerializeField] UnityEvent _onStartAttack;

    void Update()
    {
        _checkTargetToAttack();
    }

    void _checkTargetToAttack()
    {
        if(_areaToAttack._unitWithinArea.Count > 0)
        {
            _attackToUnit(_areaToAttack._unitWithinArea[0]);
        }
    }

    void _attackToUnit(Unit _targetUnit)
    {
        if(_targetUnit.gameObject.active == true && !_isAttackOnCooldown)
        {
            // if player hit enemy
            if(_targetUnit.GetComponent<UnitEnemy>() != null && this.GetComponent<UnitEnemy>() == null)
            {
                AttackUnit(_targetUnit);
            }

            // if enemy hit player
            if (_targetUnit.GetComponent<UnitEnemy>() == null && this.GetComponent<UnitEnemy>() != null)
            {
                AttackUnit(_targetUnit);
            }
        }
    }

    private void AttackUnit(Unit _targetUnit)
    {
        _targetUnit.GetComponent<UnitHealth>()._TakeDamage(_damagePerHit);
        Debug.Log($"{this.name} attack to {_targetUnit.name}");

        _onStartAttack.Invoke();

        StartCoroutine(_countAttackInterval(_attackCooldownTime));

        _checkIsTargetDead(_targetUnit);
    }

    void _checkIsTargetDead(Unit _targetUnit)
    {
        if(!_targetUnit.GetComponent<UnitHealth>()._isAlive)
        {
            _areaToAttack._RemoveUnitFromList(_targetUnit);
        }

    }

    public IEnumerator _countAttackInterval(float _cooldownTime)
    {
        _isAttackOnCooldown = true;
        yield return new WaitForSeconds(_cooldownTime);
        _isAttackOnCooldown = false;
    }
}
