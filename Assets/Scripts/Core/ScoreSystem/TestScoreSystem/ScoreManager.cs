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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("total score: " + ScoreManager.instance.ScorePoint);
        }
    }

    public void UpdateScoreCounterUI()
    {
        ScoreCounterText.text = ScorePoint.ToString();
        PlayerPrefs.SetInt("score", ScorePoint);
    }
}
