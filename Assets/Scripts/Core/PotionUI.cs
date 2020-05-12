using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionUI : MonoBehaviour
{
    Text t;
    HealingButton potion;

    private void Start()
    {
        t = GetComponent<Text>();
        potion = GameObject.FindGameObjectWithTag("Player").GetComponent<HealingButton>();
    }

    private void Update()
    {
        t.text = potion.potionCount.ToString();
    }
}
