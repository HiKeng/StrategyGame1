using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinLoseManager : SingletonBase<WinLoseManager>
{
    [Header("Variebles")]
    [SerializeField] bool _isStartObserve = false;
    [SerializeField] bool _isStageEnd = false;

    [Header("Unit List")]
    [SerializeField] List<Unit> _playerUnitList;
    [SerializeField] List<Unit> _playerBaseList;
    [SerializeField] List<Unit> _enemyUnitList;

    [Header("Events")]
    [SerializeField] UnityEvent _onStageClear;
    [SerializeField] UnityEvent _onStageFail;

    void Update()
    {
        if(!_isStartObserve) { return; }

        _checkWinLose();
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

    public void _AssignUnit(Unit _unitToAssign)
    {
        if(_unitToAssign._UnitType == Unit.UnitType.PlayerUnit)
        {
            _playerUnitList.Add(_unitToAssign);
        }

        if (_unitToAssign._UnitType == Unit.UnitType.PlayerBase)
        {
            _playerBaseList.Add(_unitToAssign);
        }

        if (_unitToAssign._UnitType == Unit.UnitType.EnemyUnit)
        {
            _enemyUnitList.Add(_unitToAssign);
        }
    }

    public void _RemoveUnit(Unit _unitToAssign)
    {
        if (_unitToAssign._UnitType == Unit.UnitType.PlayerUnit)
        {
            _playerUnitList.Remove(_unitToAssign);
        }

        if (_unitToAssign._UnitType == Unit.UnitType.PlayerBase)
        {
            _playerBaseList.Remove(_unitToAssign);
        }

        if (_unitToAssign._UnitType == Unit.UnitType.EnemyUnit)
        {
            _enemyUnitList.Remove(_unitToAssign);
        }
    }

    void _checkWinLose()
    {
        if (_enemyUnitList.Count == 0)
        {
            _StageClear();
            _isStageEnd = true;
        }

        if (_playerUnitList.Count == 0 || _playerBaseList.Count == 0)
        {
            _StageFail();
            _isStageEnd = true;
        }
    }

    public void _DestoryAllPlayerUnit()
    {
        foreach(Unit _playerUnit in _playerUnitList)
        {
            _playerUnit.gameObject.SetActive(false);
        }
    }
}
