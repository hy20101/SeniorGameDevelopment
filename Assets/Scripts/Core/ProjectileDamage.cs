using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    HealthSystem hpSystem;
    Unit unit;

    private void Start()
    {
        hpSystem = GameObject.FindGameObjectWithTag("Enemy").GetComponent<HealthSystem>();
        unit = GameObject.FindGameObjectWithTag("Player").GetComponent<Unit>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            hpSystem.AddDamage(unit.attackPower);
        }
    }
}
