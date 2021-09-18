using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    List<GameObject> _uiPageList;

    private void Awake()
    {
        _uiPageList.Clear();

        foreach(Transform child in transform.transform)
        {
            _uiPageList.Add(child.gameObject);
        }
    }

    public void _OpenPage(GameObject _pageToOpen)
    {
        for (int i = 0; i < _uiPageList.Count; i++)
        {
            _uiPageList[i].SetActive(_uiPageList[i] == _pageToOpen ? true : false);
        }
    }
}
