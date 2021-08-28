using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Unit : MonoBehaviour, IGetComponentFromChilds
{
    public bool _isPlayerControllable = true;
    [HideInInspector] public bool _isAvailableForAction;
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
            && _isPlayerControllable)
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
}
