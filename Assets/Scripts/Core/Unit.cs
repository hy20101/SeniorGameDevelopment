using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SP.Stats;

public class Unit : MonoBehaviour
{
    private float AttackDelayInSecond = 1.0f;
    private int thisId;

    public int id = -1; // Default -1 as invalid id;
    public MeleeAttack meleeAttack;
    public HealthSystem hpSystem;
    public int money;

    [SerializeField] CharacterClass characterClass;

    //TODO: Change it into equipment system or stat to get Attack damage
    public int attackPower = 10;
    private void Start()
    {
        if (tag == "Player")
        {
            money = 10;
        }
    }

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

        if (tag == "Player")
        {
            if (characterClass == CharacterClass.Warrior)
            {
                hpSystem.maxHealth = 200;
                attackPower = 15;
            }
            else if (characterClass == CharacterClass.Archer)
            {
                hpSystem.maxHealth = 150;
                attackPower = 20;
            }
            else if (characterClass == CharacterClass.Wizard)
            {
                hpSystem.maxHealth = 100;
                attackPower = 25;
            }
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
