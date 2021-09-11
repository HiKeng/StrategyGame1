using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trails : MonoBehaviour
{
    Transform _transfromParent;

    Vector3 _positionToMove;

    private void Awake()
    {
        _transfromParent = transform.parent;
    }

    void Start()
    {
        transform.parent = null;
    }

    void Update()
    {
        _positionToMove = transform.position + (_transfromParent.transform.position - transform.position);

        transform.position = _positionToMove;
    }
}
