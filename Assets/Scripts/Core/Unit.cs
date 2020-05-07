using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SP.Stats;

public class Unit : MonoBehaviour
{
    private float AttackDelayInSecond = 1.0f;
    private int thisId;
    private int count;
    private int count1;
    private int count2;
    private int count3;
    private int count4;

    public int weaponDamage = 0;
    public int armorHealth = 0;
    public int id = -1; // Default -1 as invalid id;
    public MeleeAttack meleeAttack;
    public HealthSystem hpSystem;
    public int money;
    public int attackPower = 10;

    public bool weaponUpgrade1;
    public bool weaponUpgrade2;
    public bool weaponUpgrade3;
    public bool armorUpgrade1;
    public bool armorUpgrade2;

    [SerializeField] CharacterClass characterClass;
    public CharacterSelectionControl charaSelect;

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
                hpSystem.maxHealth = 200 + armorHealth;
                attackPower = 15;
            }
            else if (characterClass == CharacterClass.Archer)
            {
                hpSystem.maxHealth = 150 + armorHealth;
                attackPower = 20;
            }
            else if (characterClass == CharacterClass.Wizard)
            {
                hpSystem.maxHealth = 100 + armorHealth;
                attackPower = 25;
            }
        }
    }

    private void Update()
    {
        if (tag == "Player")
        {
            if (weaponUpgrade1 == true)
            {
                weaponDamage = 15;
                if (count == 0)
                {
                    attackPower += weaponDamage;
                    count++;
                }
            }
            if (weaponUpgrade2 == true)
            {
                weaponDamage = 20;
                if (count1 == 0)
                {
                    attackPower += weaponDamage;
                    count1++;
                }
            }
            if (weaponUpgrade3 == true)
            {
                weaponDamage = 30;
                if (count2 == 0)
                {
                    attackPower += weaponDamage;
                    count2++;
                }
            }
            if (armorUpgrade1 == true)
            {
                armorHealth = 100;
                if (count3 == 0)
                {
                    hpSystem.maxHealth += armorHealth;
                    count3++;
                }
            }
            if (armorUpgrade2 == true)
            {
                armorHealth = 200;
                if (count4 == 0)
                {
                    hpSystem.maxHealth += armorHealth;
                    count4++;
                }
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
