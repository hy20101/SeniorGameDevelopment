﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthSystem : MonoBehaviour
{
    AnimatorControlTest animator;
    //GameObject GO;

    public float maxHealth;
    public float currentHealth;
    public int curDeathCount;
    bool isAlive;
    
    private int EnemyScore = 100;
    //SceneTransition sceneTransition;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void Start()
    {
        animator = GetComponent<AnimatorControlTest>();
        //GO = GetComponent<GameObject>();

       // print("Tag = "+GO.gameObject.tag);

        isAlive = true;
        currentHealth = maxHealth;
        //GetComponent<SceneTransition>().deathCount = curDeathCount;
    }

    public void Update()
    {

        if (currentHealth <= 0)
        {
            print("hay");
            print("Also dead");
            isAlive = false;

            //animator.animator.SetBool("AliveBool", isAlive);

            //StartCoroutine(waitThreeSeconds());
            /*if (collision.gameObject.tag != "Player")
            { SetScore(); }*/
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
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

        if (this.tag == "Enemy")
        {
            SetScore();
        }
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

    public void AddDamage (float damageReceive)
    {
        ModifyHealth(-damageReceive);
    }

    public void SetScore()
    {
        ScoreManager.instance.ScorePoint += EnemyScore;
        ScoreManager.instance.UpdateScoreCounterUI();
    }

}