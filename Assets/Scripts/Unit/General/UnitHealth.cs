using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] float _health = 100f;

    [SerializeField] UnityEvent _onTakeDamage;
    [SerializeField] UnityEvent _onDead;

    bool _isAlive = true;

    public virtual void _TakeDamage(float _damageToTake)
    {
        _health -= _damageToTake;

        _onTakeDamage.Invoke();

        if(_health <= 0)
        {
            _dead();
        }
    }

    public void _dead()
    {
        _onDead.Invoke();
    }
}
