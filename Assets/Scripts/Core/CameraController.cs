using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetToFollow;
    public Vector3 targetOffset;
    public float movementSpeed;
    public float minZoom;
    public float maxZoom;
    public float sensitivity;

    void Start()
    {
        targetOffset.y = 20f;
        movementSpeed = 3f;
        minZoom = 10f;
        maxZoom = 20f;
        sensitivity = 5f;
    }

    void Update()
    {
        MoveCamera();
        ZoomInOut();
    }

    void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, targetToFollow.position + targetOffset, movementSpeed * Time.deltaTime);
    }

    void ZoomInOut()
    {
        targetOffset.y += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        targetOffset.y = Mathf.Clamp(targetOffset.y, minZoom, maxZoom);
    }
}
