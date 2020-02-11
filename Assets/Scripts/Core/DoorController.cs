using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject instructions;

    private void Start()
    {
        instructions.SetActive(false);
    }
    
    private void OnTriggerStay(Collider other)
    {   
        if (other.tag == "Door")
        {
            instructions.SetActive(true);
            Animator anim = other.GetComponentInChildren<Animator>();
            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetTrigger("OpenClose");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")
        {
            instructions.SetActive(false);
        }
    }
}
