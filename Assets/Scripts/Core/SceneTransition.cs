using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //DeathCount deathCount;
    //EnemySpawner enemySpawner;
   
    public bool isEnable;
    public int deathCount;
    public string loadedScene;
    //public string firstScene;
    //public string secondScene;
    //public string thirdScene;

    private void Start()
    {
        isEnable = false;
        deathCount = 0;
        //gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadedScene);
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
