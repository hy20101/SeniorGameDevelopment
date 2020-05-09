using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField]
    TextMeshProUGUI ScoreCounterText;
    [HideInInspector]

    public int ScorePoint;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScoreCounterUI()
    {
        ScoreCounterText.text = ScorePoint.ToString();
        print("ha hoi");
        PlayerPrefs.SetInt("score", ScorePoint);
    }
}
