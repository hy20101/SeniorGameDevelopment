using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    [SerializeField]
    TextMeshProUGUI MoneyText;
    [HideInInspector]

    public int Money;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateMoneyUI()
    {
        MoneyText.text = Money.ToString();
    }
}
