using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image foregroundImage;
    public float updateSpeedSecond = 0.5f;

    public HealthSystem healthSystem;

    private void Awake()
    {
        if (healthSystem != null)
        {
            healthSystem.OnHealthPctChanged += HandleHealthChanged;
        }  
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
}
