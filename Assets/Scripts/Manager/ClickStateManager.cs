using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickStateManager : MonoBehaviour
{
    [HideInInspector] public bool _isClickAble = true;

    [SerializeField] float _clickCooldown = 0.25f;

    public enum ClickState
    {
        Idle,
        UnitFocus,
        UnitPrepareToMove
    }

    public ClickState _CurrentState;

    public Unit _unitToFocus;

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
        _unitToFocus = null;
        _ChangeClickState(ClickState.Idle);
    }

    public void _FocusOnUnit(Unit _targetUnit)
    {
        _ChangeClickState(ClickState.UnitFocus);

        _unitToFocus = _targetUnit;
        UnitActionManager.Instance._ShowActionMenu();
    }
}


