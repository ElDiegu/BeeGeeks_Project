using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = FindObjectOfType<SoundManager>().GetMusicVolume();
    }

    void Update()
    {
        _audioSource.volume = FindObjectOfType<SoundManager>().GetMusicVolume();
    }
}
