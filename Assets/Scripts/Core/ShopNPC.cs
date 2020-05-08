using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopNPC : MonoBehaviour
{
    HealingButton healButton;
    Unit unit;

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
    }

    public void wpUpgrade1Buy()
    {
        unit.weaponUpgrade1 = true;
        buyButton1.gameObject.SetActive(false);
    }

    public void wpUpgrade2Buy()
    {
        unit.weaponUpgrade2 = true;
        buyButton2.gameObject.SetActive(false);
    }

    public void wpUpgrade3Buy()
    {
        unit.weaponUpgrade3 = true;
        buyButton3.gameObject.SetActive(false);
    }

    public void arUpgrade1Buy()
    {
        unit.armorUpgrade1 = true;
        buyButton4.gameObject.SetActive(false);
    }

    public void arUpgrade2Buy()
    {
        unit.armorUpgrade2 = true;
        buyButton5.gameObject.SetActive(false);
    }

    public void potionBuy()
    {
        healButton.potionCount++;
    }
}
