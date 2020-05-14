using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public bool isEnable;

    [SerializeField] private string toScene;
    private SceneController sceneController;
    private KillCountManager killCount;

    private void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
        killCount = GameObject.Find("ScoreManager").GetComponent<KillCountManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            killCount.ResetKill();
            killCount.UpdateKillCounterUI();
            if (SceneController.prevScene == "Demo_Level2" && SceneController.currentScene == "Shop")
            {
                sceneController.LoadScene("Demo_Level3");
            }
            else
            {
                sceneController.LoadScene(toScene);
            }
        }
    }

    /*void Update()
    {
        print("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        if (killCount.CheckKill())
        {
            Debug.Log("portal spawn");
            gameObject.SetActive(true);
        }
    }*/
}
