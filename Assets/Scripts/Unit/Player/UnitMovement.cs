using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] bool _isMoving;

    [SerializeField] UnityEvent _onStartMoving; 
    [SerializeField] UnityEvent _onUpdateMoving;
    [SerializeField] UnityEvent _onEndMoving;

    // constant speed
    // move directly to the destination

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void _MoveToPosition(Tile _destination)
    {
        Vector3 _startingPoint = transform.position;


    }

    
}
