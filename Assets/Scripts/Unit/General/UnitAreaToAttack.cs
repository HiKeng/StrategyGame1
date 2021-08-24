using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UnitAreaToAttack : MonoBehaviour
{
    [SerializeField] List<ActionArea> _actionAreaList;

    [SerializeField] public List<Unit> _unitWithinArea;

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
}
