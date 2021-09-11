using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UnitActionBar : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] float _maxActionValue = 100f;
    [SerializeField] float _startingActionValue = 50f;
    float _currentActionValue = 0f;
    [SerializeField] float _speedMultiplier = 1f;

    [HideInInspector] public bool _isActionBarReady = false;

    [Header("UI")]
    [SerializeField] Slider _actionBarSlider;

    [Header("Event")]
    [SerializeField] UnityEvent _onActionBarStartMax;
    [SerializeField] UnityEvent _onActionBarReset;

    void Start()
    {
        _currentActionValue = _startingActionValue;

        _actionBarSlider.maxValue = _maxActionValue;
        _actionBarSlider.value = _startingActionValue;
    }

    void Update()
    {
        if(UnitDeployManager.Instance._isUnitDeployPhase) { return; }

        if(!_isActionBarReady)
        {
            _currentActionValue += Time.deltaTime * _speedMultiplier;
        }

        if(_currentActionValue >= _maxActionValue && !_isActionBarReady)
        {
            _isActionBarReady = true;
            _currentActionValue = _maxActionValue;

            _onActionBarStartMax.Invoke();
        }

        _actionBarSlider.value = _currentActionValue;
    }

    public void _ActionBarReset()
    {
        _currentActionValue = 0f;
        _isActionBarReady = false;

        _onActionBarReset.Invoke();
    }
}
