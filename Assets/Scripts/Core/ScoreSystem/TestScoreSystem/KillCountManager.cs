using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class KillCountManager : MonoBehaviour
{
    public static KillCountManager instance;

    SceneTransition sceneTransition;

    [SerializeField]
    TextMeshProUGUI KillCounterText;
    //[HideInInspector]

    public int KillCounted;
    public int MaxKill = 10;

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

    /*void Start()
    {
        sceneTransition = GameObject.Find("SceneTransition").GetComponent<SceneTransition>();
        sceneTransition.gameObject.SetActive(false);
    }

    void Update()
    {
        if (KillCounted == MaxKill)
        {
            //loadScene();
            sceneTransition.gameObject.SetActive(true);
        }
    }*/

    public void UpdateKillCounterUI()
    {
        KillCounterText.text = KillCounted.ToString();
    }

    /*public void loadScene()
    {
        SceneManager.LoadScene(6);
    }*/
}
