using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    // Reference https://docs.unity3d.com/ScriptReference/CharacterController.html
    public CharacterController characterController;

    public float speed = 12.0f;
    [Tooltip("Minus gravity for natural gravity")]
    public float gravity = -9.81f;
    public float jumpHeight = 8.0f;
    public float rotateSpeed = 80;
    float rotation = 0f;

    Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (characterController.isGrounded)
        {
            float z = Input.GetAxis("Vertical");
            moveDirection = transform.forward * z;
            moveDirection *= speed;
            Jump();
        }

        float x = Input.GetAxis("Horizontal");
        rotation = x * rotateSpeed * Time.deltaTime;

        // Free fall physics g(T^2)
        moveDirection.y += gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

        transform.Rotate(Vector3.up * rotation);
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
