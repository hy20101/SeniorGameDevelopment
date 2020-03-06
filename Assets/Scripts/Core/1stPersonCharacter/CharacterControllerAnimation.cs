using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerAnimation : MonoBehaviour
{
    public CharacterControllerMovement characterControllerMovement;
    public Animator animator;

    // Speed that can be considered the unit is moving
    public string speedParameter = "speed";

    // Start is called before the first frame update
    void Start()
    {
        characterControllerMovement = GetComponent<CharacterControllerMovement>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(characterControllerMovement.CurrentMoveSpeed != 0)
        {
            animator.SetFloat(speedParameter, characterControllerMovement.CurrentMoveSpeed);
        }
    }
}
