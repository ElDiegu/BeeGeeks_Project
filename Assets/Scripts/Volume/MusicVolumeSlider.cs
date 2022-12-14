using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MusicVolumeSlider : MonoBehaviour
{
    private Slider _slider;

    void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = FindObjectOfType<SoundManager>().GetMusicVolume();

        _slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    private void ValueChangeCheck()
    {
        Debug.Log("is this happening");
        FindObjectOfType<SoundManager>().SetMusicVolume(_slider.value);
    }
}
