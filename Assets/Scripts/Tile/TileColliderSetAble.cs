using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColliderSetAble : MonoBehaviour
{
    [SerializeField] List<BoxCollider> _tileColliderList;

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
}
