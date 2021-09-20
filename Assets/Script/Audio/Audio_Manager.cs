using UnityEngine;
using UnityEngine.Audio;
using System;

public class Audio_Manager : SingletonBase<Audio_Manager>
{
    [SerializeField] AudioMixer audioMixer;

    public Sound[] SFXsounds;

    AudioSource audioSource;

    public AudioClip hitClip;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        //_loadAudioSavedSetting();

    }

    public void playSFX(int index)
    {
        hitClip = SFXsounds[index].clip;
        audioSource.PlayOneShot(hitClip);
    }

    public void _playThisSFX(AudioClip _sfxToPlay)
    {
        hitClip = _sfxToPlay;
        audioSource.PlayOneShot(hitClip);
    }

    public void PlaySampleSFX(AudioClip _SampleSFX, bool _isPlayed)
    {
        if(_isPlayed)
        {
            audioSource.Play(0);
        }
        else
        {
            audioSource.Stop();
        }
    }

    void _loadAudioSavedSetting()
    {
        audioMixer.SetFloat("Master_Volume", Mathf.Log10(PlayerPrefs.GetFloat("Master_Volume")) * 20);
        audioMixer.SetFloat("SFX_Volume", Mathf.Log10(PlayerPrefs.GetFloat("SFX_Volume")) * 20);
        audioMixer.SetFloat("BGM_Volume", Mathf.Log10(PlayerPrefs.GetFloat("BGM_Volume")) * 20);
    }
}
