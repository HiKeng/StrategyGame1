using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tile))]
public class Tile_UnitPlacement : Tile 
{
    [SerializeField] Unit _currentActiveUnitOnTile = null;
    [SerializeField] Vector3 _placingOffset = new Vector3(0f, 10f, 0f);

    public void _droppingUnit(GameObject _unitPrefab)
    {
        _isUnitActive = true;

        Debug.Log($"Placing unit at >> {gameObject.name}");

        Vector3 _placingPos = new Vector3(gameObject.transform.position.x + _placingOffset.x,
                                         gameObject.transform.position.y + _placingOffset.y,
                                         gameObject.transform.position.z + _placingOffset.z);

        GameObject _newUnit = Instantiate(_unitPrefab, _placingPos, Quaternion.identity);
        _currentActiveUnitOnTile = _newUnit.GetComponent<Unit>();
    }

    public Vector3 _GetPlacingOffset()
    {
        return _placingOffset;
    }

    public void _AssignNewUnitActive(Unit _unitToAssign)
    {
        _currentActiveUnitOnTile = _unitToAssign;
    }

    public void _ResetUnitActive()
    {
        _currentActiveUnitOnTile = null;
        Debug.Log("Activate NUll");
    }
}
