using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitAttack : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] public float _attackCooldownTime = 20f;
    [SerializeField] public float _damagePerHit = 20f;
    public bool _isAttackOnCooldown = false;
    [SerializeField] public Unit _aimOnUnit;
    [SerializeField] public Unit _attackOnUnit;
    [SerializeField] public float _delayBeforeAttacak = 0.5f;
    [SerializeField] float _delayCount;

    [Header("References")]
    [SerializeField] public UnitAreaToAttack _areaToAttack;

    [Header("Events")]
    [SerializeField] public UnityEvent _onStartAttack;

    public virtual void Update()
    {
        _checkTargetToAttack();
        _checkTargetOutFromArea();

        if(_aimOnUnit != null)
        {

            if (_aimOnUnit.GetComponent<UnitHealth>()._isAlive == false)
            {
                _aimOnUnit = null;
            }
        }

        _checkAttackOnUnit(_aimOnUnit);
    }

    public virtual void _checkTargetToAttack()
    {
        if(_areaToAttack._unitWithinArea.Count > 0 && _aimOnUnit == null)
        {
            _aimOnUnit = _areaToAttack._unitWithinArea[0];
            Debug.LogWarning($"{this.name} added {_areaToAttack._unitWithinArea[0].name} to list.");
        }

        if(_aimOnUnit != null && _aimOnUnit.GetComponent<UnitHealth>()._isAlive && _attackOnUnit != null)
        {
            _attackToUnit(_attackOnUnit);
        }
        else
        {
            //_aimOnUnit = null;
        }
    }

    public virtual void _attackToUnit(Unit _targetUnit)
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

    public virtual void AttackUnit(Unit _targetUnit)
    {
        _targetUnit.GetComponent<UnitHealth>()._TakeDamage(_damagePerHit);
        Debug.Log($"{this.name} attack to {_targetUnit.name}");

        _onStartAttack.Invoke();

        StartCoroutine(_countAttackInterval(_attackCooldownTime));

        _checkIsTargetDead(_targetUnit);
    }

    public virtual void _checkIsTargetDead(Unit _targetUnit)
    {
        if(!_aimOnUnit.GetComponent<UnitHealth>()._isAlive)
        {
            _areaToAttack._RemoveUnitFromList(_targetUnit);
            _aimOnUnit = null;
        }
    }

    public virtual void _checkTargetOutFromArea()
    {
        if(!_areaToAttack._unitWithinArea.Contains(_aimOnUnit)) { _aimOnUnit = null; }
    }

    public IEnumerator _countAttackInterval(float _cooldownTime)
    {
        _isAttackOnCooldown = true;
        yield return new WaitForSeconds(_cooldownTime);
        _isAttackOnCooldown = false;
    }

    public virtual void _checkAttackOnUnit(Unit _targetUnit)
    {
        if(_aimOnUnit != null)
        {
            if(_delayCount < _delayBeforeAttacak)
            {
                _delayCount += Time.deltaTime;
            }

            if (_delayCount >= _delayBeforeAttacak)
            {
                _attackOnUnit = _aimOnUnit;
            }
        }

        else if(_aimOnUnit == null)
        {
            _delayCount = 0;
            _attackOnUnit = null;
        }
    }
}
