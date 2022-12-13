using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GeneralVolumeSlider : MonoBehaviour
{
    private Slider _slider;

    void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = FindObjectOfType<soundManager>().GetGeneralVolume();

        _slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    private void ValueChangeCheck()
    {
        Debug.Log("is this happening");
        FindObjectOfType<soundManager>().SetGeneralVolume(_slider.value);
    }
}
