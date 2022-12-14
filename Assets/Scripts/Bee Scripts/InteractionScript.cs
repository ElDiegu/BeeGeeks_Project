using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class InteractionScript : MonoBehaviour
{
    public float interactRadius;
    public bool interacting;
    public int honeyLevel = 0;
    public int lives = 4;
    public Transform pickPosition;
    public AudioClip boxSound;
    public AudioClip honeySound;
    public AudioClip damageSound;
    public Material beeMaterial;

    private AudioSource _audioSource;

    public void Awake()
    {
        gameObject.GetComponent<BeeUpdateUI>().UpdateHoneySprite(honeyLevel);
        gameObject.GetComponent<BeeUpdateUI>().UpdateLivesSprite(lives);

        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = FindObjectOfType<SoundManager>().GetSfxVolume();
    }

    #region Pick Interaction
    public bool picking;
    GameObject pickedItem;
    #endregion
    public void FindInteractableObject()
    {
        if (picking)
        {
            Drop(pickedItem);
            return;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, interactRadius).Where(collider => collider.gameObject.tag == "Pickable").ToArray();

        if (colliders.Length <= 0) return;

        Pick(colliders[0].gameObject);
    }

    public void Drop(GameObject pickedObject)
    {
        pickedObject.transform.parent = null;
        pickedItem.GetComponent<Rigidbody>().useGravity = true;
        pickedItem = null;
        picking = false;
        interacting = false;
    }

    public void Pick(GameObject interactingObject)
    {
        if (honeyLevel < 2) return;

        honeyLevel -= 2;
        gameObject.GetComponent<BeeUpdateUI>().UpdateHoneySprite(honeyLevel);
        interactingObject.GetComponent<Rigidbody>().useGravity = false;
        interactingObject.transform.position = pickPosition.position;
        pickedItem = interactingObject;
        picking = true;

        _audioSource.volume = FindObjectOfType<SoundManager>().GetSfxVolume();
        _audioSource.clip = boxSound;
        _audioSource.Play();
    }

    public void Update()
    {
        if (!GameManager.Instance.GamePaused)
        {
            if (Input.GetKeyUp(KeyCode.E)) FindInteractableObject();

            if (picking)
            {
                pickedItem.transform.position = pickPosition.position;
                pickedItem.transform.rotation = pickPosition.rotation;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Honey"))
        {
            if (honeyLevel >= 10)
            {
                return;
            }
            else
            {
                _audioSource.volume = FindObjectOfType<SoundManager>().GetSfxVolume();
                _audioSource.clip = honeySound;
                _audioSource.Play();

                if (honeyLevel+2 <= 10)
                {
                    honeyLevel += 2;
                }
                else
                {
                    honeyLevel = 10;
                }

                gameObject.GetComponentInChildren<ParticleSystem>().Play();

                gameObject.GetComponent<BeeUpdateUI>().UpdateHoneySprite(honeyLevel);

                Destroy(other.gameObject);
            }

        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            
            lives--;
            gameObject.GetComponent<BeeUpdateUI>().UpdateLivesSprite(lives);

            if (lives == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                return;
            }

            other.gameObject.GetComponent<WanderingAI>().Touched();

            StartCoroutine(ChangeColorCoroutine());

        } else if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Debug.Log("Here");

    }

    IEnumerator ChangeColorCoroutine()
    {
        _audioSource.volume = FindObjectOfType<SoundManager>().GetSfxVolume();
        _audioSource.clip = damageSound;
        _audioSource.Play();
        beeMaterial.SetColor("_BaseColor", new Color(1, 0, 0, 1));
        yield return new WaitForSeconds(0.2f);
        beeMaterial.SetColor("_BaseColor", new Color(1, 1, 1, 1));
        yield return new WaitForSeconds(0.2f);

        _audioSource.clip = damageSound;
        _audioSource.Play();
        beeMaterial.SetColor("_BaseColor", new Color(1, 0, 0, 1));
        yield return new WaitForSeconds(0.2f);
        beeMaterial.SetColor("_BaseColor", new Color(1, 1, 1, 1));
        yield return new WaitForSeconds(0.2f);

        _audioSource.clip = damageSound;
        _audioSource.Play();
        beeMaterial.SetColor("_BaseColor", new Color(1, 0, 0, 1));
        yield return new WaitForSeconds(0.2f);
        beeMaterial.SetColor("_BaseColor", new Color(1, 1, 1, 1));

    }
}
