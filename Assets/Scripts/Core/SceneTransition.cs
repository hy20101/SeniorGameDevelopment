using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //public bool isEnable;

    [SerializeField] private string toScene;
    private SceneController sceneController;

    private KillCountManager killCount;

    private int ToShop = 0;
    Scene CurrentScene;

    private void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
        killCount = GameObject.Find("ScoreManager").GetComponent<KillCountManager>();
        CurrentScene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            killCount.ResetKill();
            killCount.UpdateKillCounterUI();
            
            if(CurrentScene.buildIndex == 3)
            {
                ToShop++;
                SceneManager.LoadScene(6);
                SetPositionLevelShop();
            }
            else if(CurrentScene.buildIndex == 4)
            {
                ToShop++;
                SceneManager.LoadScene(6);
                SetPositionLevelShop();
            }
            else if (CurrentScene.buildIndex == 5)
            {
                SceneManager.LoadScene(7);
            }
            else if (CurrentScene.buildIndex == 6)
            {
                if(ToShop == 1)
                {
                    SceneManager.LoadScene(4);
                    SetPositionLevel2();
                }
                else
                {
                    SceneManager.LoadScene(5);
                    SetPositionLevel3();
                }
            }

            /*if (SceneController.prevScene == "Demo_Level2" && SceneController.currentScene == "Shop")
            {
                sceneController.LoadScene("Demo_Level3");
            }
            else
            {
                sceneController.LoadScene(toScene);
            }*/
        }
    }

    void SetPositionLevel2()
    {
        this.transform.position = new Vector3(-7, 2, -2);
    }

    void SetPositionLevel3()
    {
        this.transform.position = new Vector3(94, -12, -17);
    }

    void SetPositionLevelShop()
    {
        this.transform.position = new Vector3(0, 1, -3);
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
