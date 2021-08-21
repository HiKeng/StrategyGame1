using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickStateManager.Instance._ChangeClickState(ClickStateManager.ClickState.UnitFocus);
        }
    }
}
