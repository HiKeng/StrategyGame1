using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UnitAreaToAttack : MonoBehaviour
{
    [SerializeField] List<ActionArea> _actionAreaList;

    [SerializeField] List<Unit> _unitWithinArea;

    void Update()
    {
        _updateUnitInActionAreas();
    }

    void _updateUnitInActionAreas()
    {
        for (int i = 0; i < _actionAreaList.Count; i++)
        {
            _actionAreaList[i]._UpdateUnitInArea();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Unit>() != null)
        {
            _unitWithinArea.Add(other.GetComponent<Unit>());
            Debug.Log("Found");
        }
    }
}
