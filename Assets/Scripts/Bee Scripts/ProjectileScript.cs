using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    public AudioClip enemyDeathSound;
    private AudioSource _audioSource;

    public void Awake()
    {
        StartCoroutine(Destruction());
        _audioSource = GetComponent<AudioSource>();
        //_audioSource.volume = FindObjectOfType<SoundManager>().GetSfxVolume();
    }

    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collisiones");
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);

            //_audioSource.volume = FindObjectOfType<SoundManager>().GetSfxVolume();
            _audioSource.clip = enemyDeathSound;
            _audioSource.Play();
        }

        if (collision.gameObject.tag != "Player") Destroy(gameObject);

    }
}
