using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shottingPoint;
    public float shootingForce;
    public void Shoot()
    {
        if (gameObject.GetComponent<InteractionScript>().honeyLevel <= 0) return;
        gameObject.GetComponent<InteractionScript>().honeyLevel--;
        gameObject.GetComponent<BeeUpdateUI>().UpdateHoneySprite(gameObject.GetComponent<InteractionScript>().honeyLevel);

        Vector3 dir = transform.position - gameObject.GetComponent<ThirdPersonMovement>().cam.position;

        GameObject projectile = Instantiate(projectilePrefab, shottingPoint.transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = dir.normalized * shootingForce;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) gameObject.GetComponent<ShootingScript>().Shoot();
    }
}
