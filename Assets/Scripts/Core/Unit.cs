using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit : MonoBehaviour
{
    private float AttackDelayInSecond = 2.0f;
    public int id = -1; // Default -1 as invalid id;

    public MeleeAttack meleeAttack;

    HealthSystem hp;

    private void Awake()
    {
        if (meleeAttack == null)
        {
            meleeAttack = GetComponentInParent<MeleeAttack>();
        }
    }


    /*public void Attacked()
    {
        foreach (Unit u in melee.inRangeDict)
        {
            Unit target = u;
            if (u != null)
            {
                u.GetAttackDamage(10);
            }
            Debug.Log("check foreach");
        }
        Debug.Log("attacked");
    }*/

    /*public void RecieveAttacked(int damage)
    {
        if (GetComponent<HealthSystem>() != null)
        {
            GetComponent<HealthSystem>().getDamage(10);
        }
    }*/

    public float attackDelay()
    {
        return AttackDelayInSecond;
    }

    public int GetAttackDamage(int attackPower)
    {
        if (hp != null)
        {
            hp.ModifyHealth(-attackPower);
        }
        return attackPower;
    }
}
