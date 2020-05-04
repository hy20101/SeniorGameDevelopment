using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuButton : MonoBehaviour
{
    PauseMenu pauseMenu;

    private Button quitButton;
    private Button resumeButton;

    private void Start()
    {
        /*quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(ExitGame);

        resumeButton = GetComponent<Button>();
        resumeButton.onClick.AddListener(ResumeGame);*/
    }

    public void ResumeGame()
    {
        pauseMenu.isPause = false;
    }

    public void ExitGame()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }
}
