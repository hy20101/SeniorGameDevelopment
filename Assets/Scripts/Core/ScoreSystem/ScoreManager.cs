using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public string PlayerName;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        PlayerName = "";
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //need to change into queue enemy or something like that
        //print("update");
        if(Input.GetKeyDown("h"))
        {
            AddScore();
        }
        if(Input.GetKeyDown("g"))
        {
            EndLevel();
        }
    }

    public void AddScore()
    {
        print("Add!");
        Score += 10;
    }

    public void EndLevel()
    {
        //string entername = "jajaja";
        //EnterName(entername);
        SaveToJSON(PlayerName, Score);
    }

    public void EnterName(string name)
    {
        PlayerName = name;
        print("PlayerName = "+PlayerName);
    }

    public void CancelName()
    {
        //move to other scene
        PlayerName = "";
    }

    private void SaveToJSON(string name, int score)
    {
        print("name = "+name);
        print("score = "+score);
    }
}
