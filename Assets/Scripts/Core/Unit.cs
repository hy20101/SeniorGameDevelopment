using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit : MonoBehaviour
{
    private float AttackDelayInSecond = 2.0f;
    public int id = -1; // Default -1 as invalid id;

    public MeleeAttack meleeAttack;

    public HealthSystem hpSystem;

    //TODO: Change it into equipment system or stat to get Attack damage
    public int attackPower = 10;

    private void Awake()
    {
        if (meleeAttack == null)
        {
            meleeAttack = GetComponent<MeleeAttack>();
        }
        if (hpSystem == null)
        {
            hpSystem = GetComponent<HealthSystem>();
        }
    }


    public int GetUnitAttackPower()
    {
        return attackPower;
    }

    public void RecieveAttacked(int damage)
    {
        if (hpSystem != null)
        {
            //TODO: Close the log during production
            Debug.Log("Received Damage: " + damage);
            hpSystem.AddDamage(damage);
        }
        else
        {
            Debug.Log(name + " has no HealthSystem");
        }
    }

    public float attackDelay()
    {
        return AttackDelayInSecond;
    }
}
