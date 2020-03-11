using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetToFollow;
    public Vector3 cameraOffset;
    public float movementSpeed;
    public float minZoom;
    public float maxZoom;
    public float sensitivity;

    void Start()
    {
        cameraOffset.y = 20f;
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
        transform.position = Vector3.Lerp(transform.position, targetToFollow.position + cameraOffset, movementSpeed * Time.deltaTime);
    }

    void ZoomInOut()
    {
        cameraOffset.y += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        cameraOffset.y = Mathf.Clamp(cameraOffset.y, minZoom, maxZoom);
    }
}
