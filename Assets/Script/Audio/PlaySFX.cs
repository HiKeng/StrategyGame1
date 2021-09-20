using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    public void playSFX(AudioClip _sfx)
    {
        Audio_Manager.Instance._playThisSFX(_sfx);
    }
}
