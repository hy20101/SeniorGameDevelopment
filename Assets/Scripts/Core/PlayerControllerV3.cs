﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV3 : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotationSpeed = 0.3f;
    public float Gravity = 3f;
    public float JumpSpeed = 10f;

    private Transform CamTransform = null;

    private CharacterController characterController = null;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        CamTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //GetAxisRaw bc it doesn't add any smooth velocity or something like that
        Vector2 MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 forward = CamTransform.forward;
        Vector3 right = CamTransform.right;

        //Normalize bc when moving in both Ver and Hor it will not add both speed, it stay as 1 speed
        forward.Normalize();
        right.Normalize();

        Vector3 Direction = (forward * MoveInput.y + right * MoveInput.x).normalized;
        Vector3 GravityDirection = Vector3.zero;

        if(!characterController.isGrounded)
        {
            print("!isGrounded"); 
            GravityDirection.y -= Gravity;
        }
        else
        {
            print("isGrounded");
            if (Input.GetKeyDown("space"))
            {
                print("ha hoy");
                GravityDirection.y = JumpSpeed;
                characterController.Move(GravityDirection * Time.deltaTime);
            }
        }

        //check for rotation
        if(Direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Direction),RotationSpeed);
        }

        characterController.Move(Direction * MoveSpeed * Time.deltaTime);
        characterController.Move(GravityDirection * Time.deltaTime);
    }
}
