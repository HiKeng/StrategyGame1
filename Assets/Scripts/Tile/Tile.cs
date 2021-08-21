using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [HideInInspector] public bool _isUnitActive = false;

    const int _gridSize = 10;

    public int GetGridSize()
    {
        return _gridSize;
    }

    Vector2Int _gridPos;

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / _gridSize),
        Mathf.RoundToInt(transform.position.z / _gridSize)
        );
    }

    public void _DeployUnit(GameObject _unitPrefab)
    {
        if(!_isUnitActive)
        {
            _droppingUnit();
        }
    }

    void _droppingUnit()
    {
        _isUnitActive = false;

        Debug.Log("Placing tower at " + );
    }
}
