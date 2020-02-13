using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float rotationRate = 360;
    public float moveSpeed = 2;
    
    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";

    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        ApplyInput(moveAxis, turnAxis);
    }

    private void ApplyInput(float moveAxis, float turnAxis)
    {
        Move(moveAxis);
        Turn(turnAxis);
    }

    private void Move(float input)
    {
        transform.Translate(Vector3.forward * input * moveSpeed);
    }

    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}
