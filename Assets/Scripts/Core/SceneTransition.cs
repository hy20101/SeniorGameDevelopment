using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //DeathCount deathCount;
    //EnemySpawner enemySpawner;
   
    public bool isEnable;
    //public int deathCount;
    //public string loadedScene;
    //public string firstScene;
    //public string secondScene;
    //public string thirdScene;

    [SerializeField] private string toScene;
    private SceneController sceneController;

    private void Start()
    {
        isEnable = false;
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
        //deathCount = 0;
        //gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sceneController.LoadScene(toScene);
            //SceneManager.LoadScene(loadedScene);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(firstScene);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(secondScene);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(thirdScene);
        }*/
        //TODO:
        /*if (isEnable == true && deathCount == enemySpawner.maxEnemies)
        {
            gameObject.SetActive(true);
        }*/
    }
}
