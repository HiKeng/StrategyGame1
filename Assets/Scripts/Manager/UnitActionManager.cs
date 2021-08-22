﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitActionManager : MonoBehaviour
{
    [SerializeField] GameObject _actionMenu;
    [SerializeField] GameObject _actionList;
    [SerializeField] Vector3 _actionMenuSpawnPointOffset;

    [Header("Events")]
    [SerializeField] UnityEvent _onShowActionMenu;
    [SerializeField] UnityEvent _onCloseActionMenu;
    [SerializeField] UnityEvent _onSelectMoveUnit;
    [SerializeField] UnityEvent _onStartMoveUnit;

    #region Singleton

    public static UnitActionManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion


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
        ClickStateManager.Instance._ChangeClickState(ClickStateManager.ClickState.UnitPrepareToMove);
        _CloseActionMenu();
    }

    public void _StartMoveUnit(Tile _targetPosition)
    {
        // Focus unit moveToPosition()
        // reset focus()
        // event invoke()

        ClickStateManager.Instance._unitToFocus.GetComponent<UnitMovement>()._MoveToPosition(_targetPosition);

        Debug.Log("Unit start move to " + _targetPosition.name);
        ClickStateManager.Instance._ChangeClickState(ClickStateManager.ClickState.Idle);
        _onStartMoveUnit.Invoke();
    }
}
