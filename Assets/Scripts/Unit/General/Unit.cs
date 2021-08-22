﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool _isAvailableForAction;
    public Tile _AvailableOnTile;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && ClickStateManager.Instance._isClickAble && _isAvailableForAction)
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
