using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDebug : MonoBehaviour
{
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
}
