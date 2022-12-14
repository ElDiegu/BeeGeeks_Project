using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableButton : MonoBehaviour
{
    public GameObject door;
    public AudioClip buttonSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        //_audioSource.volume = FindObjectOfType<SoundManager>().GetSfxVolume();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Projectile")
        door.GetComponent<DoorScript>().OpenDoor();
        //_audioSource.volume = FindObjectOfType<SoundManager>().GetSfxVolume();
        _audioSource.clip = buttonSound;
        _audioSource.Play();
    }
}
