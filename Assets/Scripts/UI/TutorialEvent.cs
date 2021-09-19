using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialEvent : MonoBehaviour
{
    public UnityEvent onStart;

    public void Start()
    {
        onStart.Invoke();
    }
}
