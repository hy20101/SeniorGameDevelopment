using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinimapManager : MonoBehaviour
{

    public Camera playerCam;
    public Camera MinimapCam;
    bool isMapOpen = false; 
    bool isPause = false;

    Scene CurrentScene;

    // Start is called before the first frame update
    void Start()
    {
        playerCam.enabled = true;
        MinimapCam.enabled = false;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScene = SceneManager.GetActiveScene();
        if (CurrentScene.buildIndex == 3)
        {
            MinimapCam.transform.position = new Vector3(11, 90, 8);
        }
        else if (CurrentScene.buildIndex == 4)
        {
            MinimapCam.transform.position = new Vector3(-3, 86, -25);
        }
        else if (CurrentScene.buildIndex == 5)
        {
            MinimapCam.transform.position = new Vector3(70, 230, 0);
        }
        else if (CurrentScene.buildIndex == 6)
        {
            MinimapCam.transform.position = new Vector3(1, 20, 1);
        }


        if (Input.GetKeyDown("m"))
        {
            if(isMapOpen == false)
            {
                playerCam.enabled = false;
                MinimapCam.enabled = true;

                isMapOpen = true;

                Pause();
            }
            else if(isMapOpen == true)
            {
                playerCam.enabled = true;
                MinimapCam.enabled = false;

                isMapOpen = false;

                Resume();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        isPause = true;
    }
    private void Resume()
    {
        Time.timeScale = 1f;
        isPause = false;
    }
}
