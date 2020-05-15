using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    Animator animator;
    //GameObject GO;

    public float maxHealth;
    public float currentHealth;
    public int curDeathCount;
    public bool isAlive;
    
    public int EnemyScore = 100;
    public int MoneyWorth = 10;
    //SceneTransition sceneTransition;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void Start()
    {
        animator = GetComponent<Animator>();
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
            isAlive = false;

            animator.SetBool("AliveBool", isAlive);

            StartCoroutine(waitThreeSeconds());

            /*if (collision.gameObject.tag != "Player")
            { SetScore(); }*/
            //OnDisable();
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
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

        if (this.tag == "Player")
        {
            SceneManager.LoadScene("Test_score");
        }

        if (this.tag == "Enemy")
        {
            SetScore();
            KillCounted();
            MoneyAdded();
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

    public void KillCounted()
    {
        KillCountManager.instance.KillCounted++;
        KillCountManager.instance.UpdateKillCounterUI();
    }

    public void MoneyAdded()
    {
        MoneyManager.instance.Money += MoneyWorth;
        MoneyManager.instance.UpdateMoneyUI();
    }
}
