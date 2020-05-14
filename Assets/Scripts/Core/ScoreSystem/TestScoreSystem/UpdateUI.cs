using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    /*private ScoreManager scoreCount;
    private KillCountManager killCount;
    private MoneyManager moneyCount;

    // Start is called before the first frame update
    void Start()
    {
        scoreCount = GetComponent<ScoreManager>();
        killCount = GetComponent<KillCountManager>();
        moneyCount = GetComponent<MoneyManager>();
    }*/

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateKill();
        UpdateMoney();
    }

    public void UpdateScore()
    {
        ScoreManager.instance.UpdateScoreCounterUI();
    }

    public void UpdateKill()
    {
        KillCountManager.instance.UpdateKillCounterUI();
    }

    public void UpdateMoney()
    {
        MoneyManager.instance.UpdateMoneyUI();
    }
}
