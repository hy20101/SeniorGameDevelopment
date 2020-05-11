using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystemPlayer : MonoBehaviour
{
    AnimatorControlTest animator;

    public float maxHealth;
    public float currentHealth;
    public int curDeathCount;
    bool isAlive;

    //SceneTransition sceneTransition;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void Start()
    {
        animator = GetComponent<AnimatorControlTest>();

        isAlive = true;
        currentHealth = maxHealth;
        //GetComponent<SceneTransition>().deathCount = curDeathCount;
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            print("hay");
            isAlive = false;

            animator.animator.SetBool("DieTrgger", !isAlive);

            StartCoroutine(waitThreeSeconds());

            //OnDisable();
            //TODO:
            /*if (CompareTag("Enemy"))
            {
                curDeathCount = sceneTransition.deathCount + 1;
            }*/
        }
        /*if (Input.GetKeyDown(KeyCode.V) && tag == "Player")
        {
            AddDamage(10);
        }*/
    }

    IEnumerator waitThreeSeconds()
    {
        print("ha hoi");
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    public float GetHealthPercent()
    {
        return currentHealth / maxHealth;
    }

    public void ModifyHealth(float amount)
    {
        Debug.Log("Modifying Health by " + amount);
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    public void AddDamage(float damageReceive)
    {
        ModifyHealth(-damageReceive);
    }
}
