using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tile))]
public class Tile_UnitPlacement : Tile 
{
    public bool _isUnitActive = false;

    [SerializeField] public Unit _currentActiveUnitOnTile = null;
    [SerializeField] Vector3 _placingOffset = new Vector3(0f, 10f, 0f);

    public Vector3 _GetPlacingOffset()
    {
        return _placingOffset;
    }

    public void _DroppingUnit(GameObject _unitPrefab)
    {
        _isUnitActive = true;

        Debug.Log($"Placing {_unitPrefab.name} at >> {gameObject.name}");

        Vector3 _placingPos = new Vector3(gameObject.transform.position.x + _placingOffset.x,
                                         gameObject.transform.position.y + _placingOffset.y,
                                         gameObject.transform.position.z + _placingOffset.z);

        GameObject _newUnit = Instantiate(_unitPrefab, _placingPos, Quaternion.identity);
        _currentActiveUnitOnTile = _newUnit.GetComponent<Unit>();
        _newUnit.GetComponent<Unit>()._AvailableOnTile = GetComponent<Tile>();
    }

    public void _AssignNewUnitActive(Unit _unitToAssign)
    {
        _currentActiveUnitOnTile = _unitToAssign;
    }

    public void _ResetUnitActive()
    {
        _currentActiveUnitOnTile = null;
        _isUnitActive = false;
    }

    public void _DeployUnit(GameObject _unitPrefab)
    {
        if (!_isUnitActive)
        {
            GetComponent<Tile_UnitPlacement>()._DroppingUnit(_unitPrefab);
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && ClickStateManager.Instance._isClickAble)
        {
            if (ClickStateManager.Instance._CurrentState == ClickStateManager.ClickState.Idle)
            {
                if (!_isUnitActive)
                {
                    //_DeployUnit(UnitDeployManager.Instance._playerUnitPrefab);
                }
                else
                {
                    //Debug.Log("Can't place a unit");
                }
            }

            if (ClickStateManager.Instance._CurrentState == ClickStateManager.ClickState.UnitPrepareToMove)
            {
                UnitActionManager.Instance._StartMoveUnit(GetComponent<Tile>());
            }

            ClickStateManager.Instance._clickDelayCount();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _ResetUnitActive();
    }
}
