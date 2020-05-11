using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingButton : MonoBehaviour
{
    HealthSystem hpSystem;

    public int potionCount = 5;
    [SerializeField] int recoverAmount = 50;

    private void Awake()
    {
        if (hpSystem == null)
        {
            hpSystem = GetComponent<HealthSystem>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (potionCount != 0)
            {
                if (hpSystem.currentHealth < hpSystem.maxHealth)
                {
                    hpSystem.ModifyHealth(recoverAmount);
                    if (hpSystem.currentHealth > hpSystem.maxHealth)
                    {
                        hpSystem.currentHealth = hpSystem.maxHealth;
                    }
                    potionCount--;
                }
            }
            else
            {
                Debug.Log("Out of potion!");
            }
        }
    }
}
