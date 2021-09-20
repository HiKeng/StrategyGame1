using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    public void _playSFX(AudioClip _sfx)
    {
        Audio_Manager.Instance.playSFX(0);
    }
}
