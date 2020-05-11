using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class ProjectileDamage : MonoBehaviour
{
    HealthSystem hpSystem;
    Unit unit;

    private void Start()
    {
        hpSystem = GameObject.FindGameObjectWithTag("Enemy").GetComponent<HealthSystem>();
        unit = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Unit>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //hpSystem.AddDamage(unit.attackPower);
            hpSystem.AddDamage(unit.GetUnitAttackPower());
        }
    }
}
