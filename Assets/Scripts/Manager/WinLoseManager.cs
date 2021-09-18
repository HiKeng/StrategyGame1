using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinLoseManager : SingletonBase<WinLoseManager>
{
    [Header("Variebles")]
    [SerializeField] bool _isStartObserve = false;

    [Header("Unit List")]
    [SerializeField] List<GameObject> _enemyUnitList;
    [SerializeField] List<GameObject> _playerUnitList;
    [SerializeField] List<GameObject> _playerBaseList;

    [Header("Events")]
    [SerializeField] UnityEvent _onStageClear;
    [SerializeField] UnityEvent _onStageFail;

    void Start()
    {
        
    }

    void Update()
    {
        if(!_isStartObserve) { return; }

        if(_enemyUnitList == null)
        {
            _StageClear();
        }

        if (_playerUnitList == null || _playerBaseList == null)
        {
            _StageFail();
        }
    }

    public void _StageClear()
    {
        _onStageClear.Invoke();
    }

    public void _StageFail()
    {
        _onStageFail.Invoke();
    }

    public void _StartObserve()
    {
        _isStartObserve = true;
    }
}
