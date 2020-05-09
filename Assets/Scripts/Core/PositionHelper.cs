using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionHelper : SceneController
{
    public Transform player;

    public override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player").transform;
        /*if (prevScene == "Shop")
        {
            player.position = new Vector3(0f, 3f, 0f);
        }*/

        switch (prevScene) {
            case "Demo_Level1":
                player.position = new Vector3(1.25f, 0.05f, -0.5f);
                break;
            case "Demo_Level2":
                player.position = new Vector3(1.25f, 0.05f, -0.5f);
                break;
            case "Shop":
                player.position = new Vector3(1f, 3f, 1f);
                break;
        }
    }

    /*private void Update()
    {
        player = GameObject.FindWithTag("Player").transform;
    }*/
}
