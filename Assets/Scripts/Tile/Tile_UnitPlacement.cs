﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tile))]
public class Tile_UnitPlacement : Tile 
{
    [SerializeField] Unit _activeUnit = null;
    [SerializeField] Vector3 _placingOffset = new Vector3(0f, 10f, 0f);

    public void _droppingUnit(GameObject _unitPrefab)
    {
        _isUnitActive = true;

        Debug.Log("Placing tower at " + gameObject.name);

        Vector3 _placingPos = new Vector3(gameObject.transform.position.x + _placingOffset.x,
                                         gameObject.transform.position.y + _placingOffset.y,
                                         gameObject.transform.position.z + _placingOffset.z);

        GameObject _newUnit = Instantiate(_unitPrefab, _placingPos, Quaternion.identity);
        _activeUnit = _newUnit.GetComponent<Unit>();
    }
}
