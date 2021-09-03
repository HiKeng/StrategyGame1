using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAreaToAttack : MonoBehaviour, IGetComponentFromChilds
{
    [SerializeField] public List<ActionArea> _actionAreaList;

    [SerializeField] public List<Unit> _unitWithinArea;

    private void Awake()
    {
        _GetComponentFromChildrens(gameObject);
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
}
