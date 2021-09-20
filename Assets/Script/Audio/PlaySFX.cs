using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaySFX : MonoBehaviour
{
    public UnityEvent _onStart;

    private void Start()
    {
        _onStart.Invoke();
    }

    public void _playSFX(AudioClip _sfxToPlay)
    {
        Audio_Manager.Instance._playThisSFX(_sfxToPlay);
    }
}
