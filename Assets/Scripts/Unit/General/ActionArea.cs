using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionArea : Tile
{
    UnitAreaToAttack _unitAttackArea;

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

    private void AddNewUnit(Collider other)
    {
        if (other.GetComponent<Unit>() != null && other != this)
        {
            _unitInArea.Add(other.GetComponent<Unit>());
            _UpdateAddUnitInArea(other.GetComponent<Unit>());
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
}
