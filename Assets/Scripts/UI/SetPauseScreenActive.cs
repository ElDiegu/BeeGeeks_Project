using System;
using UnityEngine;

public class SetPauseScreenActive : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _HUD;

    [SerializeField] private AudioClip _playTheme;
    [SerializeField] private AudioClip _menuTheme;
    
   
    private AudioSource _audioSource;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = FindObjectOfType<SoundManager>().GetMusicVolume();
        _audioSource.clip = _playTheme;
        _audioSource.Play();
    }

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

        _audioSource.volume = FindObjectOfType<SoundManager>().GetSfxVolume();
        _audioSource.clip = _menuTheme;
        _audioSource.Play();


    }

    public void UnpauseGame()
    {
        GameManager.Instance.GamePaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1;

        _pauseMenu.SetActive(false);
        _HUD.SetActive(true);

        _audioSource.volume = FindObjectOfType<SoundManager>().GetSfxVolume();
        _audioSource.clip = _playTheme;
        _audioSource.Play();

    }
}
