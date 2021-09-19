using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : SingletonBase<TutorialManager>
{
    [SerializeField] List<GameObject> _popUps;
    int _popUpIndex = -1;

    void Start()
    {
        _UpdatePopUp(0);
    }

    public void _UpdatePopUp(int _indexToUpdate)
    {
        if(_popUpIndex >= _indexToUpdate) { return; }

        _popUpIndex = _indexToUpdate;

        for (int i = 0; i < _popUps.Count; i++)
        {
            if(_popUps[i] != null)

            if (i == _popUpIndex)
            {
                _popUps[i].SetActive(true);
            }
            else
            {
                _popUps[i].SetActive(false);
            }
        }
    }

    public void _UpdateToNextPopUp()
    {
        _popUpIndex++;

        for (int i = 0; i < _popUps.Count; i++)
        {
            if (_popUps[i] != null)

                if (i == _popUpIndex)
                {
                    _popUps[i].SetActive(true);
                }
                else
                {
                    _popUps[i].SetActive(false);
                }
        }
    }
}
