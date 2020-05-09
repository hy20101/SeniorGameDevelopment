using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionMouse : MonoBehaviour
{

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadPreScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadTourMenu()
    {
        SceneManager.LoadScene(8);
    }

    public void LoadTour1()
    {
        SceneManager.LoadScene(9);
    }

    public void LoadTour2()
    {
        SceneManager.LoadScene(10);
    }

    public void LoadTour3()
    {
        SceneManager.LoadScene(11);
    }

    public void LoadTour4()
    {
        SceneManager.LoadScene(12);
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
