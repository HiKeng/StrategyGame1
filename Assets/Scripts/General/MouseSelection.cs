using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelection : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnMouseOver()
    {
        Debug.Log("Mouse is over " + this.name);

        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log($"Clicked on {this.name}");
        }
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse is on longer on " + this.name);
    }
}
