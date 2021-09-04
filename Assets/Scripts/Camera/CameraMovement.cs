using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Vector3 _originalPosition;
    [SerializeField] Camera _mainCamera;

    [SerializeField] Vector3 _positionToMove;
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _smoothSpeed = 1f;
    [SerializeField] float _zoomSpeed;
    Vector3 velocity = Vector3.zero;

    void Start()
    {
        _originalPosition = transform.position;
        _positionToMove = _originalPosition;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            _positionToMove = new Vector3(_positionToMove.x , _positionToMove.y, _positionToMove.z + 1 * _moveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _positionToMove = new Vector3(_positionToMove.x, _positionToMove.y, _positionToMove.z - 1 * _moveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _positionToMove = new Vector3(_positionToMove.x + 1 * _moveSpeed, _positionToMove.y, _positionToMove.z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _positionToMove = new Vector3(_positionToMove.x - 1 * _moveSpeed, _positionToMove.y, _positionToMove.z);
        }

        //transform.position = Vector3.SmoothDamp(transform.position, _positionToMove, ref velocity, _speed);
        transform.position = Vector3.Lerp(transform.position, _positionToMove, _smoothSpeed * Time.deltaTime);


        if (Input.GetAxis("Mouse ScrollWheel") > 0f) 
        {
            _mainCamera.orthographicSize += 1 * _zoomSpeed;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            _mainCamera.orthographicSize -= 1 * _zoomSpeed;
        }
    }
}
