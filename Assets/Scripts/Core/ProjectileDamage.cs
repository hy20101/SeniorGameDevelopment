using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    HealthSystem hpSystem;
    Unit unit;

    private void Start()
    {
        hpSystem = GetComponent<HealthSystem>();
        unit = GetComponent<Unit>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            hpSystem.AddDamage(unit.attackPower);
        }
    }
}
