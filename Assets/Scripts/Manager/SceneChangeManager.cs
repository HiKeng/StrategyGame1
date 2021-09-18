using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : SingletonBase<SceneChangeManager>
{
    [SerializeField] bool _isTitleScreen;
    [SerializeField] int _sceneIndex;
    [SerializeField] List<string> _sceneList;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _LoadNextStage();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            _LoadPreviousStage();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_isTitleScreen)
            {
                Application.Quit();
            }
            else
            {
                _LoadScene("Title");
            }
        }
    }

    public void _LoadPreviousStage()
    {
        SceneManager.LoadScene(_sceneList[_sceneIndex - 1]);
    }

    public void _LoadNextStage()
    {
        SceneManager.LoadScene(_sceneList[_sceneIndex + 1]);
    }

    public void _LoadScene(string _sceneToLoad)
    {
        SceneManager.LoadScene(_sceneToLoad);
    }

    public void _LoadCurrentScene()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }

    public void _LoadTitleScreen()
    {
        SceneManager.LoadScene("Title");
    }
}
