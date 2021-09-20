using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    public void _playSFX(AudioClip _sfxToPlay)
    {
        Audio_Manager.Instance._playThisSFX(_sfxToPlay);
    }
}
