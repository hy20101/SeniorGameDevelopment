using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 12.0f;
    public float gravity = -9.81f;
    public float jumpheight = 8.0f;

    public Transform groundCheckGO;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public float CurrentMoveSpeed { get; set; } = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Create a tiny sphere then check for the collision with params of distance and layer
        isGrounded = Physics.CheckSphere(groundCheckGO.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Global coordiante is not what we want, use local direction of player instead
        //Vector3 move = new Vector3(x, 0f, z);

        Vector3 move = transform.right * x + transform.forward * z;

        CurrentMoveSpeed = move.magnitude * speed * Time.deltaTime;

        characterController.Move(move * speed * Time.deltaTime);



        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Equation to calculate velocity of hump height
            velocity.y = Mathf.Sqrt(jumpheight * -2 * gravity);
        }

        // Simulate fall velocity 
        // Physic of Free fall = g * time^2
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

    }
}
