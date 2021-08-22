using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    public bool _isPlayerControllable = true;
    public bool _isAvailableForAction;
    public Tile _AvailableOnTile;

    public UnityEvent onFocus;
    public UnityEvent onNotFocus;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) 
            && ClickStateManager.Instance._isClickAble && _isAvailableForAction
            && _isPlayerControllable)
        {
            ClickStateManager.Instance._FocusOnUnit(GetComponent<Unit>());
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
    
}
