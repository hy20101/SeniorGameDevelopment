using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            anim.Play("Idel", -1, 0f);
        }
        if (Input.GetKeyDown("2"))
        {
            anim.Play("WalkNormal", -1, 0f);
        }
        if (Input.GetKeyDown("3"))
        {
            anim.Play("WalkInjured", -1, 0f);
        }
        if (Input.GetKeyDown("4"))
        {
            anim.Play("WalkLackadaisical", -1, 0f);
        }
        if (Input.GetKeyDown("5"))
        {
            anim.Play("Die", -1, 0f);
        }
        if(Input.GetMouseButtonDown(0))
        {
            anim.Play("AttackSword_1hPiecece", -1, 0f);
        }
    }
}
