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
            GetComponent<Tile_UnitPlacement>()._droppingUnit(_unitPrefab);
        }
    }


    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && ClickStateManager.Instance._isClickAble)
        {
            ClickStateManager.Instance._clickDelayCount();

            if(ClickStateManager.Instance._CurrentState == ClickStateManager.ClickState.Idle)
            {
                if (!_isUnitActive)
                {
                    _DeployUnit(UnitDeployManager.Instance._playerUnitPrefab);
                }
                else
                {
                    Debug.Log("Can't place a unit");
                }
            }

            else
            {
                ClickStateManager.Instance._ResetFocus();
            }
        }
    }
}
