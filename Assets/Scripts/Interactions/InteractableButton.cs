using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : MonoBehaviour
{
    public GameObject door;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Pickable") return;

        door.GetComponent<DoorScript>().OpenDoor();
    }

    public void OnCollisionExit(Collision collision)
    {
        door.GetComponent<DoorScript>().CloseDoor();
    }
}
