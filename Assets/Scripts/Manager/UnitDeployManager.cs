using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class UnitDeployManager : SingletonBase<UnitDeployManager>
{
    [SerializeField] int _unitLimitAmount = 3;
    int _currentUnitAmount = 0;

    [SerializeField] TextMeshProUGUI _amountLeftUI;

    [HideInInspector] public GameObject _UnitPrefab;
    [HideInInspector] public bool _isUnitDeployPhase = true;

    [Header("Events")]
    public UnityEvent _onStart;
    public UnityEvent _onPrepareDeployUnit;
    public UnityEvent _onDeployUnit;
    public UnityEvent _onReachedUnitLimit;
    public UnityEvent _onEndDeployPhase;

    private void Start()
    {
        _onStart.Invoke();
    }

    public bool _IsNotExceedUnitLimitAmount()
    {
        return _currentUnitAmount < _unitLimitAmount;
    }

    public void _IncreaseCurrentUnitAmount()
    {
        _currentUnitAmount++;

        if(!_IsNotExceedUnitLimitAmount()) { _onReachedUnitLimit.Invoke(); }
    }

    public void _OnPrepareDeployUnit()
    {
        _onPrepareDeployUnit.Invoke();
    }

    public void _UpdateAmountLeftUI()
    {
        _amountLeftUI.text = $"{_unitLimitAmount - _currentUnitAmount} Left";
    }

    public void _EndDeployPhase()
    {
        _isUnitDeployPhase = false;
        _onEndDeployPhase.Invoke();
    }
}
