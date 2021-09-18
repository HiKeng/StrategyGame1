using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] List<GameObject> _uiPageList;

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
            //if(uiPageList[i] == _pageToOpen)
            //{
            //    uiPageList[i].SetActive(true);
            //}
            //else
            //{
            //    uiPageList[i].SetActive(false);
            //}

            _uiPageList[i].SetActive(_uiPageList[i] == _pageToOpen ? true : false);
        }
    }
}
