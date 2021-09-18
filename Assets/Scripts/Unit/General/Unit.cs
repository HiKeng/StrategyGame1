using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Unit : MonoBehaviour, IGetComponentFromChilds
{
    public bool _isPlayerControllable = true;

    [System.Serializable]
    public enum UnitType
    {
        PlayerUnit,
        PlayerBase,
        EnemyUnit
    }

    public UnitType _UnitType;

    [SerializeField] bool _isPlacedOnStart = false;
    Vector3 _colliderCheckSize = new Vector3(0.5f, 8f, 0.5f);
    [HideInInspector] public bool _isAvailableForAction;
    public LayerMask m_LayerMask;
    public Tile _AvailableOnTile;
    
    [SerializeField] GameObject _areaToAttack;

    [HideInInspector] public List<ActionArea> _areaVisualList;

    [Header("Event")]
    public UnityEvent onStart;
    public UnityEvent onFocus;
    public UnityEvent onNotFocus;

    private void Awake()
    {
        _GetComponentFromChildrens(_areaToAttack);
        _AssignUnitToList();
    }

    void Start()
    {
        onStart.Invoke();
    }

    void OnMouseOver()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0)
            && ClickStateManager.Instance._isClickAble && _isAvailableForAction
            && _isPlayerControllable
            && !UnitDeployManager.Instance._isUnitDeployPhase)
            {
                ClickStateManager.Instance._ResetFocus();
                ClickStateManager.Instance._FocusOnUnit(GetComponent<Unit>());
            }
        }
    }

    public void _ChangeAvailablity(bool _isAvailable)
    {
        _isAvailableForAction = _isAvailable;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<ActionArea>() != null)
        {
            other.GetComponent<ActionArea>()._RemoveFromUnitInAreaList(this);
        }
    }

    public void _setAreaVisualActive(bool _isActive)
    {
        for (int i = 0; i < _areaVisualList.Count; i++)
        {
            _areaVisualList[i]._AreaSample.SetActive(_isActive);
        }
    }

    public void _GetComponentFromChildrens(GameObject _targetParent)
    {
        _areaVisualList.Clear();

        foreach (Transform child in _targetParent.transform)
        {
            if (child.GetComponent<ActionArea>() != null)
            {
                _areaVisualList.Add(child.GetComponent<ActionArea>());
            }
        }
    }

    public void _ResetFocusOnThisUnit()
    {
        if(ClickStateManager.Instance._unitToFocus == this)
        {
            ClickStateManager.Instance._ResetFocus();
        }
    }

    public void _RemoveAvailableOnTile()
    {
        if (_AvailableOnTile.GetComponent<Tile_UnitPlacement>()._currentActiveUnitOnTile = this)
        {
            _AvailableOnTile.GetComponent<Tile_UnitPlacement>()._ResetUnitActive();
        }
    }

    public void _AssignUnitOnStart()
    {
        if(!_isPlacedOnStart) { return; }

        Collider[] _hitCollider = Physics.OverlapBox(gameObject.transform.position, _colliderCheckSize, Quaternion.identity, m_LayerMask);

        if(_hitCollider[0] != null)
        {
            _AvailableOnTile = _hitCollider[0].GetComponent<Tile>();
            _hitCollider[0].GetComponent<Tile_UnitPlacement>()._AssignNewUnitActive(this);
        }
    }

    public void _AssignUnitToList()
    {
        WinLoseManager.Instance._AssignUnit(this);
    }
}
