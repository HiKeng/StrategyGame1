using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestory : MonoBehaviour
{
    [SerializeField] float delayTime = 1.5f;

    void Start()
    {
        Destroy(gameObject, delayTime);
    }
}
