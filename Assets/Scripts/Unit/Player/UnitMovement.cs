using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] float _tarvelTimePerTile = 1f;

    bool _isMoving;
    float _distancePerTile = 10f;
    float _speed { get { return _distancePerTile / _tarvelTimePerTile; } }
    Tile _endingTile = null;
    Vector3 _endingPoint = new Vector3();

    [SerializeField] public UnityEvent _onPrepareMoving;
    [SerializeField] UnityEvent _onStartMoving; 
    [SerializeField] UnityEvent _onUpdateMoving;
    [SerializeField] UnityEvent _onEndMoving;

    private void Start()
    {
        _endingPoint = GetComponent<Unit>()._AvailableOnTile.transform.position;
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
            transform.position = _endingPoint;
            _endingTile.GetComponent<Tile_UnitPlacement>()._AssignNewUnitActive(GetComponent<Unit>());

            Debug.Log("End moving");

            _onEndMoving.Invoke();
        }

        if (_isMoving 
            && Vector3.Distance(transform.position, _endingPoint) > 0.05f 
            && GetComponent<Unit>()._AvailableOnTile.GetComponent<Tile_UnitPlacement>() != null)
        {
            GetComponent<Unit>()._AvailableOnTile.GetComponent<Tile_UnitPlacement>()._ResetUnitActive();
        }
    }

    public void _MoveToPosition(Tile _destination)
    {
        Tile_UnitPlacement _tileUnitPlacement = _destination.GetComponent<Tile_UnitPlacement>();

        _endingPoint = _destination.transform.position + _tileUnitPlacement._GetPlacingOffset();
        _endingTile = _destination;

        _isMoving = true;
        Debug.Log("Start move");

        _onStartMoving.Invoke();
    }
}
