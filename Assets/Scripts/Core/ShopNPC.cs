using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopNPC : MonoBehaviour
{
    HealingButton healButton;
    Unit unit;
    MoneyManager moneyManager;

    public GameObject uiCanvas;
    public Button buyButton1;
    public Button buyButton2;
    public Button buyButton3;
    public Button buyButton4;
    public Button buyButton5;

    bool uiActive = false;

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            uiActive = !uiActive;
            uiCanvas.SetActive(uiActive);
        }
    }

    private void Awake()
    {
        if (healButton == null)
        {
            healButton = GameObject.FindGameObjectWithTag("Player").GetComponent<HealingButton>();
        }
        if (unit == null)
        {
            unit = GameObject.FindGameObjectWithTag("Player").GetComponent<Unit>();
        }
        if (moneyManager == null)
        {
            moneyManager = GameObject.Find("ScoreManager").GetComponent<MoneyManager>();
        }
    }

    public void wpUpgrade1Buy()
    {
        if (moneyManager.Money >= 50 && unit.weaponUpgrade1 == false)
        {
            unit.weaponUpgrade1 = true;
            buyButton1.gameObject.SetActive(false);
            moneyManager.Money -= 50;
        }
    }

    public void wpUpgrade2Buy()
    {
        if (moneyManager.Money >= 100 && unit.weaponUpgrade2 == false)
        {
            unit.weaponUpgrade2 = true;
            buyButton2.gameObject.SetActive(false);
            moneyManager.Money -= 100;
        }
    }

    public void wpUpgrade3Buy()
    {
        if (moneyManager.Money >= 200 && unit.weaponUpgrade3 == false)
        {
            unit.weaponUpgrade3 = true;
            buyButton3.gameObject.SetActive(false);
            moneyManager.Money -= 200;
        }
    }

    public void arUpgrade1Buy()
    {
        if (moneyManager.Money >= 60 && unit.armorUpgrade1 == false)
        {
            unit.armorUpgrade1 = true;
            buyButton4.gameObject.SetActive(false);
            moneyManager.Money -= 60;
        }
    }

    public void arUpgrade2Buy()
    {
        if (moneyManager.Money >= 120 && unit.armorUpgrade2 == false)
        {
            unit.armorUpgrade2 = true;
            buyButton5.gameObject.SetActive(false);
            moneyManager.Money -= 120;
        }
    }

    public void potionBuy()
    {
        if (moneyManager.Money >= 30)
        {
            healButton.potionCount++;
            moneyManager.Money -= 30;
        }
    }
}
