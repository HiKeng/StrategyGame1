using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] UnitAreaToAttack _areaToAttack;

    [SerializeField] float _attackInterval = 20f;
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
        if(_targetUnit.gameObject.active == true
            && !_isAttackOnCooldown)
        {
            _targetUnit.GetComponent<UnitHealth>()._TakeDamage(_damagePerHit);
            Debug.Log($"{this.name} attack to {_targetUnit.name}");

            _onStartAttack.Invoke();

            StartCoroutine(_countAttackInterval(_attackInterval));
        }
    }

    public IEnumerator _countAttackInterval(float _cooldownTime)
    {
        _isAttackOnCooldown = true;
        yield return new WaitForSeconds(_cooldownTime);
        _isAttackOnCooldown = false;
    }
}
