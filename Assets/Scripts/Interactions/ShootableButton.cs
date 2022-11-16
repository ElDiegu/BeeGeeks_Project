using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableButton : MonoBehaviour
{
    public GameObject door;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Projectile")
        door.GetComponent<DoorScript>().OpenDoor();
    }
}
