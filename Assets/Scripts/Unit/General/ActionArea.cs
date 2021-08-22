using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionArea : Tile
{
    [SerializeField] UnitAreaToAttack _unitAttackArea;

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
        if(other.GetComponent<Unit>() != null)
        {
            _unitInArea.Add(other.GetComponent<Unit>());
            _UpdateAddUnitInArea(other.GetComponent<Unit>());
        }
    }

    public void _RemoveFromUnitInAreaList(Unit _unitToRemove)
    {
        _unitInArea.Remove(_unitToRemove);
        _UpdateRemoveUnitInArea(_unitToRemove);
    }
}
