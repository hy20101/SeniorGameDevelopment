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
        isEnable = false;
        //this.gameObject.SetActive(false);
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
        killCount = GameObject.Find("ScoreManager").GetComponent<KillCountManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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

    /*private void Update()
    {
        if (killCount.KillCounted == killCount.MaxKill)
        {
            Debug.Log("portal spawn");
            this.gameObject.SetActive(true);
        }
    }*/
}
