using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && ClickStateManager.Instance._isClickAble)
        {
            ClickStateManager.Instance._FocusOnUnit(GetComponent<Unit>());
        }
    }
}
