using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTriggerMechanic : MonoBehaviour
{
    //When the Primitive exits the collision, it will change Color
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("กรีีดๆ someone entered " + other.name);
    }

    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        Debug.Log("กรีีดๆ someone exit " + other.name);
    }
}