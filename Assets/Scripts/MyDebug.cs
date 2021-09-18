using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyDebug : MonoBehaviour
{
    public int _moveCount;

    public void _Print(string _text)
    {
        Debug.Log(_text);
    }

    public void _PrintWarn(string _text)
    {
        Debug.LogWarning(_text);
    }

    public void _PrintError(string _text)
    {
        Debug.LogError(_text);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneChangeManager.Instance._LoadCurrentScene();
        }
    }

    public void _ChangeMoveCountValue(int _amount)
    {
        _moveCount += _amount;
    }
}
