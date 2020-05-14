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

    public GameObject portal;

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

    void Start()
    {
        portal.SetActive(false);
        /*if (sceneTransition.isEnable == true)
        {
            portal.SetActive(true);
        }*/
    }

    void Update()
    {
        //print("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        if (CheckKill())
        {
            portal.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("total kill: " + KillCounted);
        }
    }

    public bool CheckKill()
    {
        if (KillCounted == MaxKill)
        {
            return true;
        }
        return false;
    }

    public void UpdateKillCounterUI()
    {
        KillCounterText.text = KillCounted.ToString();
    }

    public void ResetKill()
    {
        KillCounted = 0;
    }
}
