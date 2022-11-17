using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InteractionScript : MonoBehaviour
{
    public float interactRadius;
    public bool interacting;
    public int honeyLevel = 0;
    public int lives = 4;
    
    public Transform pickPosition;

    public void Awake()
    {
        gameObject.GetComponent<BeeUpdateUI>().UpdateHoneySprite(honeyLevel);
        gameObject.GetComponent<BeeUpdateUI>().UpdateLivesSprite(lives);
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
        //interactingObject.transform.parent = pickPosition;
        interactingObject.transform.position = pickPosition.position;
        pickedItem = interactingObject;
        picking = true;
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
                gameObject.GetComponent<BeeUpdateUI>().UpdateHoneySprite(honeyLevel);
                if (honeyLevel+2 <= 10)
                {
                    honeyLevel += 2;
                }
                else
                {
                    honeyLevel = 10;
                }
                
                Destroy(other.gameObject);
            }

        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            lives--;
            gameObject.GetComponent<BeeUpdateUI>().UpdateLivesSprite(lives);

            other.gameObject.GetComponent<WanderingAI>().Touched();
        }

    }
}
