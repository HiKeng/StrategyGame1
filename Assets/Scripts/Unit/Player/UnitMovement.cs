using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] bool _isMoving;
    float _distanceProgress;

    [SerializeField] float _distancePerTile = 10f;
    [SerializeField] float _tarvelTimePerTile = 1f;

    float _speed { get { return _distancePerTile / _tarvelTimePerTile; } }

    [SerializeField] Vector3 _endingPoint = new Vector3();

    [SerializeField] UnityEvent _onStartMoving; 
    [SerializeField] UnityEvent _onUpdateMoving;
    [SerializeField] UnityEvent _onEndMoving;

    // constant speed
    // move directly to the destination

    void Start()
    {
        Vector3 _startingPoint = transform.position;
    }

    void FixedUpdate()
    {
        if (_isMoving)
        {
            float _step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _endingPoint, _step);
        }

        if(_isMoving && Vector3.Distance(transform.position, _endingPoint) < 0.001f)
        {
            _isMoving = false;
            Debug.Log("End moving");
        }
    }

    public void _MoveToPosition(Tile _destination)
    {
        Tile_UnitPlacement _unitPlacementOffset = _destination.GetComponent<Tile_UnitPlacement>();

        _endingPoint = _destination.transform.position + _unitPlacementOffset._GetPlacingOffset();
        _isMoving = true;
        Debug.Log("Start move");
    }

    
}
