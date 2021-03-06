using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAreaToAttack : MonoBehaviour, IGetComponentFromChilds
{
    [SerializeField] public List<ActionArea> _actionAreaList;

    [SerializeField] public List<Unit> _unitWithinArea;

    public bool _isHealUnit = false;

    private void Awake()
    {
        _GetComponentFromChildrens(gameObject);
    }

    void Update()
    {
        _checkUnitDead();
    }

    public void _RemoveUnitFromList(Unit _targetUnit)
    {
        _unitWithinArea.Remove(_targetUnit);

        for (int i = 0; i < _actionAreaList.Count; i++)
        {
            if(_actionAreaList[i]._UnitInArea.Contains(_targetUnit))
            {
                _actionAreaList[i]._UnitInArea.Remove(_targetUnit);
            }
        }
    }

    public void _GetComponentFromChildrens(GameObject _targetParent)
    {
        _actionAreaList.Clear();

        foreach (Transform child in _targetParent.transform)
        {
            if (child.GetComponent<ActionArea>() != null)
            {
                _actionAreaList.Add(child.GetComponent<ActionArea>());
            }
        }
    }

    public void _CheckNearbyTile(AttackArea_EdgeGlow _edgeGlowToCheck)
    {
        Vector2Int _targetPosition = _edgeGlowToCheck.transform.parent.GetComponent<Tile>().GetGridPos();

        Vector2Int _frontPositionToCheck = new Vector2Int(_targetPosition.x, _targetPosition.y + 1);
        Vector2Int _backPositionToCheck = new Vector2Int(_targetPosition.x, _targetPosition.y - 1);
        Vector2Int _rightPositionToCheck = new Vector2Int(_targetPosition.x + 1, _targetPosition.y);
        Vector2Int _leftPositionToCheck = new Vector2Int(_targetPosition.x - 1, _targetPosition.y);

        for (int i = 0; i < _actionAreaList.Count; i++)
        {
            if(_actionAreaList[i].GetComponent<Tile>().GetGridPos() != _targetPosition)
            {
                if (_actionAreaList[i].GetComponent<Tile>().GetGridPos() == _frontPositionToCheck)
                {
                    _edgeGlowToCheck._hasFront = true;
                }

                if (_actionAreaList[i].GetComponent<Tile>().GetGridPos() == _backPositionToCheck)
                {
                    _edgeGlowToCheck._hasBack = true;
                }

                if (_actionAreaList[i].GetComponent<Tile>().GetGridPos() == _rightPositionToCheck)
                {
                    _edgeGlowToCheck._hasRight = true;
                }

                if (_actionAreaList[i].GetComponent<Tile>().GetGridPos() == _leftPositionToCheck)
                {
                    _edgeGlowToCheck._hasLeft = true;
                }
            }
        }
    }

    void _checkUnitDead()
    {
        for (int i = 0; i < _unitWithinArea.Count; i++)
        {
            if(_unitWithinArea[i].GetComponent<UnitHealth>()._isAlive == false)
            {
                _unitWithinArea.Remove(_unitWithinArea[i]);
            }
        }
    }

    public Unit _UnitToAttackNext()
    {
        Unit _unitToAttack = null;

        if (_unitWithinArea[0].GetComponent<PlayerBase>() != null && _unitWithinArea.Count > 1)
        {
            _unitToAttack = _unitWithinArea[1];
        }

        else
        {
            _unitToAttack = _unitWithinArea[0];
        }

        return _unitToAttack;
    }
}
