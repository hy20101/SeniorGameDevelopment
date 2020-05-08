using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerReposition : MonoBehaviour
{
    private Scene scene;

    public Vector3 startPos1;

    void Start()
    {
        if (scene.name == "Demo_Level2")
        {
            Debug.Log(scene.name);
            GameObject.FindGameObjectWithTag("Player").transform.position = startPos1;
        }
    }
}
