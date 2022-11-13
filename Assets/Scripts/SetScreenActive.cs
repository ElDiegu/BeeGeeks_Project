using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreenActive : MonoBehaviour
{
    [SerializeField] private GameObject _screen;
    public void ActivateScreen()
    {
        Time.timeScale = 0;
        _screen.SetActive(true);
    }

    public void DeactivateScreen()
    {
        Time.timeScale = 1;
        _screen.SetActive(false);
    }
}
