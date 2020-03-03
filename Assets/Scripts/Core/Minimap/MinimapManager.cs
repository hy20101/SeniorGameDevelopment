using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour
{

    public Camera playerCam;
    public Camera MinimapCam;
    bool isMapOpen = false; 
    bool isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        playerCam.enabled = true;
        MinimapCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
