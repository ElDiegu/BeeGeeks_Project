using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    #region Movement
    public CharacterController controller;
    public float speed = 6.0f;
    public float smoothTurn = 0.1f;
    float turnVelocity;
    public Transform cam;
    #endregion

    #region Jump
    public bool jumping;
    public float jumpingHeight = 3.0f;
    public float verticalVelocity = 0.0f;
    float gravity = 9.81f;
    #endregion

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (!GameManager.Instance.GamePaused)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;
            Vector3 moveDirection = new Vector3(0.0f, 0.0f, 0.0f);

            transform.rotation = cam.rotation;

            if (direction.magnitude >= 0.1f)
            {
                float tangetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tangetAngle, ref turnVelocity, smoothTurn);
                transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

                moveDirection = Quaternion.Euler(0.0f, tangetAngle, 0.0f) * Vector3.forward;
                //controller.Move(moveDirection.normalized * speed * Time.deltaTime);
            }

            if (controller.isGrounded) verticalVelocity = 0.0f;

            if (Input.GetKey(KeyCode.Space) && controller.isGrounded && verticalVelocity <= 0)
            {
                verticalVelocity += Mathf.Sqrt(jumpingHeight * gravity);
            }
            else if (Input.GetKey(KeyCode.Space) && verticalVelocity <= 0)
            {
                verticalVelocity += (gravity / 2) * Time.deltaTime;
            }

            verticalVelocity -= gravity * Time.deltaTime;
            Vector3 fallVector = new Vector3(0.0f, verticalVelocity, 0.0f);
            controller.Move((moveDirection * speed + fallVector) * Time.deltaTime);
        }
    }
}
