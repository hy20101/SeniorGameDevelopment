using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class KillCountManager : MonoBehaviour
{
    public static KillCountManager instance;

    [SerializeField]
    TextMeshProUGUI KillCounterText;
    [HideInInspector]

    public int KillCounted;

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

    void Update()
    {
        if(KillCounted == 3)
        {
            loadScene();
        }
    }

    public void UpdateKillCounterUI()
    {
        KillCounterText.text = KillCounted.ToString();
        print("ha hoi kill");
        //PlayerPrefs.SetInt("score", ScorePoint);
    }

    public void loadScene()
    {
        SceneManager.LoadScene(7);
    }
}
