using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    bool isAlive;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void Start()
    {
        isAlive = true;
        currentHealth = maxHealth;
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            isAlive = false;
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.V) && tag == "Player")
        {
            AddDamage(10);
        }
    }

    public float GetHealthPercent()
    {
        return currentHealth / maxHealth;
    }

    public void ModifyHealth(float amount)
    {
        // TODO: Delete it later
        Debug.Log("Modifying Health by " + amount);
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    public void AddDamage (float damageReceive)
    {
        ModifyHealth(-damageReceive);
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
