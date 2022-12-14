using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private float _generalVolume = 1f;
    private float _musicVolume = 1f;
    private float _sfxVolume = 1f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    #region Setters
    public void SetGeneralVolume(float volume)
    {
        _generalVolume = volume;
        _musicVolume *= _generalVolume;
        _sfxVolume *= _generalVolume;
    }

    public void SetMusicVolume(float volume)
    {
        _musicVolume = volume * _generalVolume;
    }

    public void SetSfxVolume(float volume)
    {
        _sfxVolume = volume * _generalVolume;
    }

    #endregion

    #region Getters

    public float GetGeneralVolume()
    {
        return _generalVolume;
    }

    public float GetSfxVolume()
    {
        return _sfxVolume;
    }

    public float GetMusicVolume()
    {
        return _musicVolume;
    }

    #endregion
}
