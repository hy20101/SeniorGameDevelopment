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
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.H) && tag == "Player")
=======
        if (Input.GetKeyDown(KeyCode.F))
>>>>>>> 59c3f04103e7db53abaeb3a4bba5fd089e428f11
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
