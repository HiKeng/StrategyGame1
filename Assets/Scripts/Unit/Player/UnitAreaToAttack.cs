using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UnitAreaToAttack : MonoBehaviour
{
    [SerializeField] List<ActionArea> _actionAreaList;

    [HideInInspector] public List<Unit> _unitWithinArea;
}
