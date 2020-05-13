using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpScript : MonoBehaviour
{
    public GameObject HelpUI;

    void Start()
    {
        HelpUI.SetActive(false);
    }

    public void OpenHelp()
    {
        HelpUI.SetActive(true);
    }

    public void CloseHelp()
    {
        HelpUI.SetActive(false);
    }

    public void LoadAboutUs()
    {
        SceneManager.LoadScene(13);
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
