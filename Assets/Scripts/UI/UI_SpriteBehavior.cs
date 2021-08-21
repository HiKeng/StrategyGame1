using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SpriteBehavior : MonoBehaviour
{
    [SerializeField] bool _lookAtCamera = true;


    private void Update()
    {
        _spriteBehavior();
    }
    void _spriteBehavior()
    {
        if(_lookAtCamera)
        {
            transform.LookAt(Camera.main.transform.position, Vector3.up);
        }
    }
}
