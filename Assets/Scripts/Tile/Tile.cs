using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject _areaSample;

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

    public void _setAreaSampleActive(bool _isActive)
    {
        _areaSample.SetActive(_isActive);
    }
}
