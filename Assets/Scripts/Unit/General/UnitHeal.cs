using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHeal : UnitAttack
{
    public override void Update()
    {
        base.Update();
    }

    public override void _attackToUnit(Unit _targetUnit)
    {
        if (_targetUnit.gameObject.active == true && !_isAttackOnCooldown)
        {
            // if player heal player
            if (_targetUnit.GetComponent<UnitEnemy>() != null && this.GetComponent<UnitEnemy>() != null)
            {
                _healUnit(_targetUnit);

            }

            // if enemy heal enemy
            if (_targetUnit.GetComponent<UnitEnemy>() == null && this.GetComponent<UnitEnemy>() == null)
            {
                _healUnit(_targetUnit);
            }
        }
    }

    public override void AttackUnit(Unit _targetUnit)
    {
        
    }

    void _healUnit(Unit _targetUnit)
    {
        _targetUnit.GetComponent<UnitHealth>()._Heal(_damagePerHit);
        Debug.Log($"{this.name} heal to {_targetUnit.name}");

        _onStartAttack.Invoke();
        StartCoroutine(_countAttackInterval(_attackCooldownTime));
    }
}
