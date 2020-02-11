using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
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
    }

    public float GetHealthPercent()
    {
        return currentHealth / maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    public void getDamage (int damageReceive)
    {
        currentHealth -= damageReceive;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
