using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : SingletonBase<SceneChangeManager>
{
    [SerializeField] int _sceneIndex;
    [SerializeField] List<string> _sceneList;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(_sceneList[_sceneIndex + 1]);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(_sceneList[_sceneIndex - 1]);
        }
    }

    public void _LoadScene(string _sceneToLoad)
    {
        SceneManager.LoadScene(_sceneToLoad);
    }
}
