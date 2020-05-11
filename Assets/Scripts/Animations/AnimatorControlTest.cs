 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControlTest : MonoBehaviour
{
    public Animator animator;
    public bool isalive = true;
    public bool attackMuay = true;
    public bool attackSword = true;
    public bool attackBow = true;
    public bool attackMagic = true;
    public float movementSpeed = 0;
    
    void Start()
    {
        if (animator)
        {
            animator = gameObject.GetComponent<Animator>();
        }
    }
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        //----Control Trigger----//
        if (Input.GetKeyDown("space")) // Hello
        {
            print("Say Hello");
            //Reset trigger
            animator.ResetTrigger("DoHelloTrigger");

            //Send the message to the Animator to activate the trigger parameter 
            animator.SetTrigger("DoHelloTrigger");
        }
        if (Input.GetKeyDown(KeyCode.P)) // Pick Up
        {
            print("Aready Picked");
            //Reset trigger
            animator.ResetTrigger("PickUpTrigger");

            //Send the message to the Animator to activate the trigger parameter 
            animator.SetTrigger("PickUpTrigger");
        }
        if (Input.GetKeyDown(KeyCode.O)) // Open Door
        {
            print("Aready Opened Door");
            //Reset trigger
            animator.ResetTrigger("OpenDoorTrigger");

            //Send the message to the Animator to activate the trigger parameter 
            animator.SetTrigger("OpenDoorTrigger");
        }
        if (Input.GetKeyDown(KeyCode.C)) // Open Chest
        {
            print("Aready Opened Chest");
            //Reset trigger
            animator.ResetTrigger("OpenChestTrigger");

            //Send the message to the Animator to activate the trigger parameter 
            animator.SetTrigger("OpenChestTrigger");
        }


        //----Control Bool----//
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isalive = !isalive;
            print("isalive = " + isalive);

            animator.SetBool("AliveBool", isalive);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            attackMuay = !attackMuay;
            print("attackMuay = " + attackMuay);

            animator.SetBool("AttackMuayBool", attackMuay);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            attackSword = !attackSword;
            print("attackSword = " + attackSword);

            animator.SetBool("AttackSwordBool", attackSword);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            attackBow = !attackBow;
            print("attackBow = " + attackBow);

            animator.SetBool("AttackBowBool", attackBow);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            attackMagic = !attackMagic;
            print("attackBow = " + attackMagic);

            animator.SetBool("AttackMagicBool", attackMagic);
        }

        //-----Control Float-----//
        /*if (Input.GetKeyDown(KeyCode.A))
        {

            movementSpeed -= 2.0f;
            if(movementSpeed <= 0)
            {
                movementSpeed = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movementSpeed += 2.0f;
        }*/
        animator.SetBool("AliveBool", isalive);
        animator.SetFloat("MoveSpeed", movementSpeed);

    }

}
