using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleManager : SingletonBase<TimeScaleManager>
{
    [SerializeField] float _speedUpScale = 2f;
    [SerializeField] float _slowTimeScale = 0.5f;

    bool _isScaleChanged;

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            _isScaleChanged = true;
            Time.timeScale = _slowTimeScale;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            _isScaleChanged = true;
            Time.timeScale = _speedUpScale;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            _isScaleChanged = false;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            _isScaleChanged = false;
        }

        if (!_isScaleChanged)
        {
            Time.timeScale = 1f;
        }
    }

    public void _SlowTime()
    {
        _isScaleChanged = true;

        Time.timeScale = _slowTimeScale;
    }

    public void _DisableSlowTime()
    {
        _isScaleChanged = false;

        Time.timeScale = 1f;
    }
}
