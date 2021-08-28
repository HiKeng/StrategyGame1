using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Vector3 _originalPosition;

    [SerializeField] Vector3 _positionToMove;
    [SerializeField] float _speed = 1f;
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
            _positionToMove = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z );
        }

        if (Input.GetKey(KeyCode.S))
        {
            _positionToMove = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _positionToMove = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _positionToMove = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
        }

        transform.localPosition = Vector3.SmoothDamp(transform.position, _positionToMove, ref velocity, _speed);
    }
}
