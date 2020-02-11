using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[RequireComponent(typeof(Unit))]
public class MeleeAttack : MonoBehaviour
{
    [SerializeField]
    Collider attackRange;

    Unit objectUnit;
    //Unit newId;

    public int inRangeUnitCount;

    float delayTimer;
    bool isDelayAttack;

    public IDictionary<int, Unit> inRangeDict;

    private void Start()
    {
        objectUnit = GetComponent<Unit>();
        //TODO: Find a way to make it search for all colliders then check for the one with right tags
        //attackRange = GetComponents<Unit>();

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
            Debug.Log("fire");
            StartCoroutine("Attack");
        }
        else // Test print all dictionary
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("I-key print all dictionary");
            // Loop print out dictionary key value
            for (int i = 0; i < inRangeUnitCount; i++)
            {
                Debug.Log(inRangeDict[inRangeDict.Keys.ElementAt(i)]);
            }
        }
    }

    IEnumerator Attack()
    {
        if (isDelayAttack == false)
        {
            //gameObject.GetComponent<HealthSystem>().getDamage(10);
            Debug.Log("Attacking!!!! Success");
            isDelayAttack = true;
            delayTimer = objectUnit.attackDelay();
            StartCoroutine("CountDownDelay");
        }
        else
        {
            Debug.Log("Attacking!!!! Fail - delayed");
        }
        return null;
    }

    IEnumerator CountDownDelay()
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

    /*private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Damagable" || other.tag == "Enemy" || other.tag == "Player")
        {
            //Debug.Log(other.tag);
            if(other.GetComponent<Unit>() != null)
            {
                //other.gameObject.GetComponent<HealthSystem>().getDamage(10);
                Unit newUnit = other.GetComponent<Unit>();
                int id = newUnit.id;
                if (id != -1)
                {
                    if (!inRangeDict.ContainsKey(id))
                    {
                        Debug.Log("check in range");
                        inRangeDict.Add(id, newUnit);
                        // TODO: ถ้ามี key  อยู่แล้ว add ไม่ได้  หาวิธีใส่่ทับลงไป
                        inRangeUnitCount++;
                        Debug.Log("Add Unit to inRangeDict, total = " + inRangeUnitCount);
                    }
                    //Unit u = new Unit();
                    //u.Attacked();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Damagable" || other.tag == "Enemy" || other.tag == "Player")
        {
            //Debug.Log(other.tag);
            if (other.GetComponent<Unit>() != null)
            {
                Unit newUnit = other.GetComponent<Unit>();
                int id = newUnit.id;
                if (id != -1)
                {
                    inRangeDict.Remove(id);
                    inRangeUnitCount--;
                    //Debug.Log("Remove Unit to inRangeDict, total = " + inRangeUnitCount);
                }

            }
        }
    }*/
}
