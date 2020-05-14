using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionHelper : SceneController
{
    public Transform player;
    
    [SerializeField] Vector3 Position = new Vector3(0f, 0f, 0f);
    [SerializeField] Vector3 shopPos = new Vector3(0f, 0f, 0f);

    public override void Start()
    {
        base.Start();
        shopPos = new Vector3(1.25f, 0.05f, -0.5f);
        player = GameObject.FindWithTag("Player").transform;

        switch (prevScene) {
            case "Demo_Level1":
                player.position = shopPos;
                break;
            case "Demo_Level2":
                player.position = shopPos;
                break;
            case "Shop":
                player.position = Position;
                if (prevScene == "Demo_Level2")
                {
                    player.position = Position;
                }
                break;
        }
        
        /*if (prevScene == "Demo_Level1")
        {
            player.position = shopPos;
        }
        else if (prevScene == "Demo_Level2")
        {
            player.position = shopPos;
        }
        else if (prevScene == "Shop")
        {
            player.position = Position;
            if (prevScene == "Demo_Level2")
            {
                player.position = Position;
            }
        }*/
    }
}
