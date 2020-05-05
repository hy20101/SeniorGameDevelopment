using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingButton : MonoBehaviour
{
    HealthSystem hpSystem;

    [SerializeField] int potionCount = 5;

    private void Awake()
    {
        if (hpSystem == null)
        {
            hpSystem = GetComponent<HealthSystem>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (potionCount != 0)
            {
                if (hpSystem.currentHealth != hpSystem.maxHealth)
                {
                    hpSystem.ModifyHealth(20);
                    potionCount--;
                }
            }
        }
    }
}
