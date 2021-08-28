using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelection : MonoBehaviour
{
    [SerializeField] bool _isCheckClick = false;

    RaycastHit hit;

    void Start()
    {
        
    }

    void Update()
    {
        //if(_isCheckClick)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //        if (Physics.Raycast(ray, out hit, 2f))
        //        {
        //            Debug.LogWarning("object that was hit: " + hit.collider.gameObject.name);
        //        }
        //    }
        //}
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
