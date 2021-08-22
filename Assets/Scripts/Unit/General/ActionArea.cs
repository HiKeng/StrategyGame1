using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionArea : Tile
{
    [SerializeField] List<Unit> _unitInArea;



    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void _UpdateUnitInArea()
    {
        Debug.Log("Hello");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Unit>() != null)
        {
            _unitInArea.Add(other.GetComponent<Unit>());
        }
    }
}
