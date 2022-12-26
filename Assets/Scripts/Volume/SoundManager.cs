using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private float _generalVolume = 1f;
    private float _generalSlider = 1f;
    private float _musicSlider = 1f;
    private float _sfxSlider = 1f;
    private float _musicVolume = 1f;
    private float _sfxVolume = 1f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    #region Setters
    public void SetGeneralVolume(float volume)
    {
        _generalSlider = volume;
        _generalVolume = _generalSlider;
        _musicVolume = _musicSlider * _generalSlider;
        _sfxVolume = _sfxSlider * _generalSlider;
    }

    public void SetMusicVolume(float volume)
    {
        _musicSlider = volume;
        _musicVolume = volume * _generalSlider;
    }

    public void SetSfxVolume(float volume)
    {
        _sfxSlider = volume;
        _sfxVolume = volume * _generalSlider;
    }

    #endregion

    #region Getters

    public float GetGeneralVolume()
    {
        return _generalSlider;
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
