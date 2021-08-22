using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickStateManager : MonoBehaviour
{
    [HideInInspector] public bool _isClickAble = true;

    [SerializeField] float _clickCooldown = 0.25f;

    public enum ClickState
    {
        Idle,
        UnitFocus,
        UnitPrepareToMove,
        UnitPrepareToAttack
    }

    public ClickState _CurrentState;

    [HideInInspector] public Unit _unitToFocus;

    [Header("Events")]
    [SerializeField] UnityEvent _onFocusOnUnit;
    [SerializeField] UnityEvent _onResetFocus;
    [SerializeField] UnityEvent _onStartUnitPrepareToMove;


    #region Singleton

    public static ClickStateManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public void _clickDelayCount()
    {
        StartCoroutine(_StartClickCooldownCount(_clickCooldown));
    }

    IEnumerator _StartClickCooldownCount(float _cooldownTime)
    {
        _isClickAble = false;

        yield return new WaitForSeconds(_cooldownTime);

        _isClickAble = true;
    }

    public void _ChangeClickState(ClickState _state)
    {
        if(_isClickAble)
        {
            _CurrentState = _state;
            Debug.Log($"Click state changed to >> {_CurrentState}");
            _clickDelayCount();
        }
        else
        {
            return;
        }
        
    }

    public void _ResetFocus()
    {
        if(_unitToFocus != null)
        {
            _unitToFocus.onNotFocus.Invoke();
        }

        _unitToFocus = null;
        _ChangeClickState(ClickState.Idle);
        _onResetFocus.Invoke();
    }

    public void _FocusOnUnit(Unit _targetUnit)
    {
        _ChangeClickState(ClickState.UnitFocus);

        _unitToFocus = _targetUnit;
        _targetUnit.onFocus.Invoke();

        UnitActionManager.Instance._ShowActionMenu();

        _onFocusOnUnit.Invoke();
    }

}


