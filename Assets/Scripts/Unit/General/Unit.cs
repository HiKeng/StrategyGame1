using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    public bool _isPlayerControllable = true;
    [HideInInspector] public bool _isAvailableForAction;
    [HideInInspector] public Tile _AvailableOnTile;

    [SerializeField] List<ActionArea> _areaVisualList;

    [Header("Event")]
    public UnityEvent onStart;
    public UnityEvent onFocus;
    public UnityEvent onNotFocus;

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
}
