using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    public void PauseGame()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
    }
}
