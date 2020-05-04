using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPause = false;
    public GameObject PauseUI;

    void Start()
    {
        HidePauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause == false)
            {
                Pause();
            }
            else if (isPause == true)
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPause = true;
        ShowPauseMenu();
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        isPause = false;
        HidePauseMenu();
    }

    private void ShowPauseMenu()
    {
        PauseUI.SetActive(true);
    }

    private void HidePauseMenu()
    {
        PauseUI.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
