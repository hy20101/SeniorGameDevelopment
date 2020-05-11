using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[RequireComponent(typeof(Unit))]
public class MeleeAttack : MonoBehaviour
{
    //AnimatorControlTest animator;

    [SerializeField]
    Collider attackRange;

    Unit myUnit;
    //Unit newId;

    public int inRangeUnitCount;

    float delayTimer;
    bool isDelayAttack;

    public Dictionary<int, Unit> inRangeDict;

    private void Start()
    {
        //animator = GetComponent<AnimatorControlTest>();

        myUnit = GetComponent<Unit>();

        delayTimer = 0f;
        isDelayAttack = false;

        inRangeDict = new Dictionary<int, Unit>();
        inRangeUnitCount = 0;

    }

    private void Update()
    {
        //Debug.Log("Update");
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("fire");
            StartCoroutine("Attack");

            
        }
        /*else // Test print all dictionary
        if (Input.GetKeyDown(KeyCode.J))
        {
            //Debug.Log("J-key print all dictionary");
            // Loop print out dictionary key value
            for (int i = 0; i < inRangeUnitCount; i++)
            {
                //Debug.Log(inRangeDict[inRangeDict.Keys.ElementAt(i)]);
            }
        }*/
    }

    public IEnumerator Attack()
    {
        if (isDelayAttack == false)
        {
            //Debug.Log("Attacking!!!! Success");
            //TODO: Add attack damage

            foreach (KeyValuePair<int, Unit> entry in inRangeDict)
            {
                // do something with entry.Value or entry.Key
                if(entry.Value != null)
                {
                    Debug.Log("Attacking: id =" + entry.Key + ", name =" + entry.Value.name + ", dmg =" + myUnit.GetUnitAttackPower());
                    entry.Value.ReceiveAttacked(myUnit.GetUnitAttackPower() );
                }
            }

            isDelayAttack = true;
            delayTimer = myUnit.attackDelay();
            StartCoroutine("CountDownDelay");

            //animator.animator.SetTrigger("AttackSword_Slash");
        }
        else
        {
            //Debug.Log("Attacking!!!! Fail - delayed");
        }
        return null;
    }

    public IEnumerator CountDownDelay()
    {

        if(isDelayAttack)
        {
            if(delayTimer <=0)
            {
                isDelayAttack = false;
            }
            else
            {
                yield return new WaitForSeconds(delayTimer);
                isDelayAttack = false;
                delayTimer = 0;
            }
        }
    }
}
