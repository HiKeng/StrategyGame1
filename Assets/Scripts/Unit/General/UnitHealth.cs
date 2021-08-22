﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour
{
    public bool _isAlive = true;
    [SerializeField] public float _MaxHealth = 100f;
    [HideInInspector] public float _CurrentHealth = 100f;

    [Header("UI")]
    [SerializeField] Slider _healthSlider;

    [SerializeField] UnityEvent _onTakeDamage;
    [SerializeField] UnityEvent _onDead;


    private void Start()
    {
        _CurrentHealth = _MaxHealth;
        _healthSlider.maxValue = _MaxHealth;
        _healthSlider.value = _healthSlider.maxValue;
    }

    private void Update()
    {
        _healthSlider.value = _CurrentHealth;
    }

    public float _GetCurrentHealth()
    {
        return _CurrentHealth;
    }

    public virtual void _TakeDamage(float _damageToTake)
    {
        _CurrentHealth -= _damageToTake;

        _onTakeDamage.Invoke();

        if(_CurrentHealth <= 0)
        {
            _dead();
        }
    }

    public void _dead()
    {
        _isAlive = false;

        _onDead.Invoke();
    }
}
