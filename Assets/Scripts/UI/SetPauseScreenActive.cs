using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPauseScreenActive : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _HUD;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        GameManager.Instance.GamePaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;

        _pauseMenu.SetActive(true);
        _HUD.SetActive(false);
    }

    public void UnpauseGame()
    {
        GameManager.Instance.GamePaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1;

        _pauseMenu.SetActive(false);
        _HUD.SetActive(true);
    }
}
