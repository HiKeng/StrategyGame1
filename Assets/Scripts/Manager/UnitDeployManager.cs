using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitDeployManager : SingletonBase<UnitDeployManager>
{
    [SerializeField] int _unitLimitAmount = 3;
    [SerializeField] int _currentUnitAmount = 0;

    public GameObject _UnitPrefab;

    public bool _isUnitDeployPhase = true;

    [Header("Events")]
    public UnityEvent _onStart;
    public UnityEvent _onDeployUnit;

    private void Start()
    {
        _onStart.Invoke();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            _isUnitDeployPhase = false;
        }
    }

    public bool _IsNotExceedUnitLimitAmount()
    {
        return _currentUnitAmount < _unitLimitAmount;
    }

    public void _IncreaseCurrentUnitAmount()
    {
        _currentUnitAmount++;
    }

    
}
