using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColliderSetAble : MonoBehaviour, IGetComponentFromChilds
{
    [SerializeField] List<BoxCollider> _tileColliderList;

    private void Awake()
    {
        _GetComponentFromChildrens(gameObject);
    }

    public void _GetComponentFromChildrens(GameObject _targetParent)
    {
        _tileColliderList.Clear();

        foreach (Transform child in _targetParent.transform)
        {
            if (child.GetComponent<Tile>() != null)
            {
                _tileColliderList.Add(child.GetComponent<BoxCollider>());
            }
        }
    }

    public void _SetTileColliderActive(bool _isActive)
    {
        for (int i = 0; i < _tileColliderList.Count; i++)
        {
            if(_tileColliderList[i] != null)
            {
                _tileColliderList[i].enabled = _isActive;
            }
        }
    }

    public void _SetTileUnitMoveAble(bool _isAcitve)
    {
        foreach(BoxCollider tile in _tileColliderList)
        {
            if(tile.gameObject.GetComponent<Tile_UnitPlacement>()._currentActiveUnitOnTile == null)
            {
                tile.gameObject.GetComponent<Tile>()._areaSample.SetActive(_isAcitve);
            }
        }
    }

    public void _RemoveAvailableOnUnitDead(Unit _targetUnit)
    {
        foreach (BoxCollider tile in _tileColliderList)
        {
            if (tile.gameObject.GetComponent<Tile_UnitPlacement>()._currentActiveUnitOnTile == _targetUnit)
            {
                tile.gameObject.GetComponent<Tile_UnitPlacement>()._ResetUnitActive();
            }
        }
    }
}
