using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            anim.SetInteger("direction", 1);
        }

        if (Input.GetKeyDown("space"))
        {
            anim.SetInteger("direction", 0);
        }
    }
}
