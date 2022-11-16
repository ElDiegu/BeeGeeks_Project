using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Vector3 originalPosition;
    Vector3 desiredPosition;
    Vector3 actualPosition;
    Vector3 openedPosition;

    public float speed = 0.5f;

    bool inPlace = true;
    public float progress;

    public void Awake()
    {
        originalPosition = transform.position;
        desiredPosition = transform.position;
        openedPosition = new Vector3(originalPosition.x, transform.position.y - gameObject.GetComponent<Collider>().bounds.size.y, originalPosition.z);
    }
    public void OpenDoor()
    {
        actualPosition = transform.position;
        desiredPosition.y = openedPosition.y;
        progress = 1 - Mathf.Abs((actualPosition.y - desiredPosition.y)/(originalPosition.y - desiredPosition.y));
    }

    public void CloseDoor()
    {
        actualPosition = transform.position;
        desiredPosition.y = originalPosition.y;
        progress = 1 - Mathf.Abs((actualPosition.y - desiredPosition.y) / (openedPosition.y - desiredPosition.y));
    }

    private void Update()
    {
        if(transform.position == desiredPosition) inPlace = true;
        else inPlace = false;

        if(!inPlace)
        {
            var position = Mathf.Lerp(actualPosition.y, desiredPosition.y, progress);
            progress += speed * Time.deltaTime;
            transform.position = new Vector3(actualPosition.x, position, actualPosition.z);
        }
    }
}
