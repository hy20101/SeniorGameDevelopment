using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float rotationRate = 360;
    public float moveSpeed = 5;
    public float jumpSpeed = 5;

    public Rigidbody rb;
    
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";

    void start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        ApplyInput(moveAxis, turnAxis);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump(100);
        }
    }

    private void ApplyInput(float moveAxis, float turnAxis)
    {
        Move(moveAxis);
        Turn(turnAxis);
    }

    private void Move(float input)
    {
        rb.AddForce(transform.forward * input * moveSpeed, ForceMode.Force);
        //transform.Translate(Vector3.forward * input * moveSpeed * Time.deltaTime);
    }

    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }

    private void Jump(float input)
    {
        rb.AddForce(Vector3.up * jumpSpeed * Time.deltaTime * input, ForceMode.Impulse);
    }
}
