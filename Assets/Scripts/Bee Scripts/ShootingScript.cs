using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shottingPoint;
    public float shootingForce;
    public void Shoot(Vector3 direction)
    {
        if (gameObject.GetComponent<InteractionScript>().honeyLevel <= 0) return;
        gameObject.GetComponent<InteractionScript>().honeyLevel--;

        GameObject projectile = Instantiate(projectilePrefab, shottingPoint.transform.position, gameObject.GetComponent<ThirdPersonMovement>().cam.rotation);
        projectile.GetComponent<Rigidbody>().AddRelativeForce((direction + new Vector3(0.0f, 0.25f, 0.0f)) * shootingForce);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) gameObject.GetComponent<ShootingScript>().Shoot(gameObject.GetComponent<ThirdPersonMovement>().cam.forward);
    }
}
