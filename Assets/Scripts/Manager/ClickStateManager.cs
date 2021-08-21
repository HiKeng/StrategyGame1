using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickStateManager : MonoBehaviour
{
    public bool _isClickAble = true;

    [SerializeField] float _clickCooldown = 0.25f;

    public enum ClickState
    {
        Idle,
        UnitFocus
    }

    public ClickState _CurrentState;

    [SerializeField] Unit _unitToFocus;

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
            Debug.Log($"Current state = {_CurrentState}");
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
        _unitToFocus = _targetUnit;
        _ChangeClickState(ClickState.UnitFocus);
    }
}


