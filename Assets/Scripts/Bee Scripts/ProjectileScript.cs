using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    public void Awake()
    {
        StartCoroutine(Destruction());
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
            Debug.Log("Here");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag != "Player") Destroy(gameObject);

    }
}
