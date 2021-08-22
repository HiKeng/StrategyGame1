using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionArea : Tile
{
    UnitAreaToAttack _unitAttackArea;

    [SerializeField] public GameObject _areaSample;
    [SerializeField] List<Unit> _unitInArea;

    void Awake()
    {
        _unitAttackArea = transform.parent.GetComponent<UnitAreaToAttack>();
    }

    public void _UpdateAddUnitInArea(Unit _targetUnit)
    {
        _unitAttackArea._unitWithinArea.Add(_targetUnit);
    }

    public void _UpdateRemoveUnitInArea(Unit _targetUnit)
    {
        _unitAttackArea._unitWithinArea.Remove(_targetUnit);
    }

    private void OnTriggerEnter(Collider other)
    {
        AddNewUnit(other);
    }

    private void OnTriggerStay(Collider other)
    {
        AddNewUnit(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Unit>() != null && other != this)
        {
            _RemoveFromUnitInAreaList(other.GetComponent<Unit>());
        }
    }

    private void AddNewUnit(Collider other)
    {
        if (other.GetComponent<Unit>() != null && other != this)
        {
            if(!_unitAttackArea._unitWithinArea.Contains(other.GetComponent<Unit>()))
            {
                _unitInArea.Add(other.GetComponent<Unit>());
                _UpdateAddUnitInArea(other.GetComponent<Unit>());
            }
        }
    }

    public void _RemoveFromUnitInAreaList(Unit _unitToRemove)
    {
        if(_unitToRemove != this)
        {
            _unitInArea.Remove(_unitToRemove);
            _UpdateRemoveUnitInArea(_unitToRemove);
        }
    }

    bool _isAlreadyAdded()
    {
        bool _isUnitAlreadyAdded = false;

        for (int i = 0; i < _unitAttackArea._unitWithinArea.Count; i++)
        {
            for (int j = 0; i < _unitInArea.Count; i++)
            {
                if (_unitAttackArea._unitWithinArea[i] == _unitInArea[j])
                {
                    _isUnitAlreadyAdded = true;
                }
                else
                {

                }
            }
            
        }

        return _isUnitAlreadyAdded;
    }
}
