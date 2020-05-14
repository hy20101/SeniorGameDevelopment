using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image foregroundImage;
    public float updateSpeedSecond = 0.5f;

    public HealthSystem healthSystem;

    CharacterSelectionControl charaSelect;

    private void Awake()
    {
        /*if (healthSystem == null)
        {
            healthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        }*/
        //healthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        if (healthSystem == null)
        {
            StartCoroutine(waitForsecond());
            StartCoroutine(healthAssign());
        }

        /*if (healthSystem != null)
        {
            print("health != null");
            healthSystem.OnHealthPctChanged += HandleHealthChanged;
        }*/
    }

    private void HandleHealthChanged(float pct)
    {
        Debug.Log("Called HandleHeathChanged with " + pct);
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;

        while(elapsed < updateSpeedSecond)
        {

            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSecond);
            yield return new WaitForEndOfFrame();
        }

        Debug.Log("foregroundImage.fillAmount ");
        foregroundImage.fillAmount = pct;
    }

    IEnumerator waitForsecond()
    {
        yield return new WaitForSeconds(1);
        print("1");
        if (CharacterSelectionControl.warriorChoose == true)
        {
            healthSystem = GameObject.Find("Player_Warrior").GetComponent<HealthSystem>();
            yield break;
        }
        else if (CharacterSelectionControl.archerChoose == true)
        {
            healthSystem = GameObject.Find("Player_Archer").GetComponent<HealthSystem>();
            yield break;
        }
        else if (CharacterSelectionControl.wizardChoose == true)
        {
            healthSystem = GameObject.Find("Player_Wizard").GetComponent<HealthSystem>();
            yield break;
        }
    }

    IEnumerator healthAssign()
    {
        yield return new WaitForSeconds(2);
        print("assign");
        healthSystem.OnHealthPctChanged += HandleHealthChanged;
        yield break;
    }
}
