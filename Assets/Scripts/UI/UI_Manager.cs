using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [HideInInspector] public List<GameObject> _uiPageList;

    private void Start()
    {
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

    public void _LoadScene(string _sceneName)
    {
        SceneChangeManager.Instance._LoadScene(_sceneName);
    }

    public void _ExitButton()
    {
        Debug.Log("Exit game.");
        Application.Quit();
    }
}
