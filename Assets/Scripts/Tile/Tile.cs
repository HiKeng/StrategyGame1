using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] public GameObject _areaSample;
    [SerializeField] Tile_UnitPlacement _unitPlacement;
    public bool _IsShowArea;

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
}
