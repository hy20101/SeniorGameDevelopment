using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseRotationSpeed = 80f;

    [Tooltip("Transform of target unit")]
    public Transform playerBody;
    [Tooltip("Transform of target camera for look up/down")]
    public Camera targetCamera;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        targetCamera =  GetComponent<Camera>();
        if (!targetCamera)
        {
            targetCamera = GetComponentInChildren<Camera>();      
        }
        if(!playerBody)
        {
            playerBody = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseRotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseRotationSpeed * Time.deltaTime;

        // Rotate Up-down
        xRotation -= mouseY;
        // Clamp the rotation of X for player to be -90 to 90
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        targetCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // Up is y-axis - so rotate left or right
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
