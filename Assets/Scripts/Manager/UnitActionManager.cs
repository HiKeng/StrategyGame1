using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitActionManager : SingletonBase<UnitActionManager>
{
    [SerializeField] GameObject _actionMenu;
    [SerializeField] GameObject _actionList;
    [SerializeField] Vector3 _actionMenuSpawnPointOffset;

    [Header("Events")]
    [SerializeField] UnityEvent _onShowActionMenu;
    [SerializeField] UnityEvent _onCloseActionMenu;

    [SerializeField] UnityEvent _onStartPrepareMoveUnit;
    [SerializeField] UnityEvent _onStartPrepareAttackUnit;

    [SerializeField] UnityEvent _onStartMoveUnit;

    public void _ShowActionMenu()
    {
        _actionMenu.SetActive(true);

        Vector3 _UnitToFocusPositionOnScreen = Camera.main.WorldToScreenPoint(ClickStateManager.Instance._unitToFocus.transform.position);

        Vector3 _actionMenuFinalPosition = new Vector3(_UnitToFocusPositionOnScreen.x + _actionMenuSpawnPointOffset.x,
                                                       _UnitToFocusPositionOnScreen.y + _actionMenuSpawnPointOffset.y,
                                                       _UnitToFocusPositionOnScreen.z + _actionMenuSpawnPointOffset.z);

        _actionList.transform.position = _actionMenuFinalPosition;

        _onShowActionMenu.Invoke();
    }

    public void _CloseActionMenu()
    {
        _actionMenu.SetActive(false);

        _onCloseActionMenu.Invoke();
    }

    public void _StartPrepareToMoveUnit()
    {
        if (ClickStateManager.Instance._unitToFocus.GetComponent<UnitActionBar>()._isActionBarReady)
        {
            ClickStateManager.Instance._ChangeClickState(ClickStateManager.ClickState.UnitPrepareToMove);
            _onStartPrepareMoveUnit.Invoke();

            ClickStateManager.Instance._ResetFocusWithOutClearUnit();

            _actionMenu.SetActive(false);

            ClickStateManager.Instance._unitToFocus.GetComponent<UnitMovement>()._onPrepareMoving.Invoke();
        }
    }

    public void _StartMoveUnit(Tile _targetPosition)
    {
        if(ClickStateManager.Instance._unitToFocus.GetComponent<UnitActionBar>()._isActionBarReady)
        {
            if (_targetPosition == null)
            {
                Debug.LogError("TargetPos == null");
            }

            if (ClickStateManager.Instance._unitToFocus.GetComponent<UnitMovement>() == null)
            {
                Debug.LogError("UnitToFocus == null");
            }

            if(_targetPosition.GetComponent<Tile_UnitPlacement>()._currentActiveUnitOnTile != null) { return; }

            ClickStateManager.Instance._unitToFocus.GetComponent<UnitMovement>()._MoveToPosition(_targetPosition);

            Debug.Log("Unit start move to " + _targetPosition.name);
            ClickStateManager.Instance._ChangeClickState(ClickStateManager.ClickState.Idle);

            ClickStateManager.Instance._unitToFocus.GetComponent<UnitActionBar>()._ActionBarReset();
            ClickStateManager.Instance._ResetFocus();

            _onStartMoveUnit.Invoke();

        }
    }

    public void _StartPrepareToAttackUnit()
    {
        ClickStateManager.Instance._ChangeClickState(ClickStateManager.ClickState.UnitPrepareToAttack);
        _CloseActionMenu();

        _onStartPrepareAttackUnit.Invoke();
    }
}
