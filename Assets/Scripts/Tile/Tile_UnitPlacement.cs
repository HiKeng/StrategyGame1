using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_UnitPlacement : Tile 
{
    [SerializeField] Vector3 _placingOffset = new Vector3(0f, 10f, 0f);

    void OnMouseOver()
    {
        Debug.Log("Over a unit");

        if (Input.GetMouseButtonDown(0))
        {
            if (!_isUnitActive)
            {
                Debug.Log("Place a unit");
            }
            else
            {
                Debug.Log("Can't place a unit");
            }
        }
    }
}
