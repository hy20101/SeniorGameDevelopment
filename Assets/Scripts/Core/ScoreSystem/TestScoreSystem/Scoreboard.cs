using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private int MaxScoreboard = 5;
    [SerializeField] private Transform TempScore = null;
    [SerializeField] private GameObject ScoreboardEntryObject = null;

    [Header("Test")]
    [SerializeField] ScoreboardEntryData test = new ScoreboardEntryData();

    private string path = "Assets/Resources/Score_JSON/Scoreboard.json";

    void Start()
    {
        //for adding input
        test.InputName = "";
        test.InputScore = 0;

        showEnterNameUI();

        ScoreboardSaveData SavedScores = GetSavedScore();
        UpdateUI(SavedScores);
        SaveScores(SavedScores);
    }

    //messing around with Json
    private ScoreboardSaveData GetSavedScore()
    {
        if(!File.Exists(path))
        {
            File.Create(path).Dispose();
            return new ScoreboardSaveData();
        }

        using (StreamReader stream = new StreamReader(path))
        {
            string json = stream.ReadToEnd();

            return JsonUtility.FromJson<ScoreboardSaveData>(json);
        }
    }

    //also messing around with Json
    private void SaveScores(ScoreboardSaveData scoreboardSaveData)
    {
        using (StreamWriter stream = new StreamWriter(path))
        {
            string json = JsonUtility.ToJson(scoreboardSaveData, true);
            stream.Write(json);
        }
    }

    //update score slot (adding and removing)
    private void UpdateUI(ScoreboardSaveData SavedScores)
    {
        foreach(Transform child in TempScore)
        {
            Destroy(child.gameObject);
        }

        foreach(ScoreboardEntryData score in SavedScores.Scores)
        {
            Instantiate(ScoreboardEntryObject, TempScore).GetComponent<ScoreboardEntryUI>().init(score);
        }
    }

    //check scores for adding, if more than max then keep the highest
    public void AddEntry(ScoreboardEntryData scoreboardEntryData)
    {
        ScoreboardSaveData SavedScores = GetSavedScore();

        bool scoreAdded = false;

        //find the higher score and save to scoreboard
        for(int i = 0; i < SavedScores.Scores.Count; i++)
        {
            if(scoreboardEntryData.InputScore > SavedScores.Scores[i].InputScore)
            {
                SavedScores.Scores.Insert(i, scoreboardEntryData);
                scoreAdded = true;
                break;
            }
        }

        //check max, if not max then add more
        if(!scoreAdded && SavedScores.Scores.Count < MaxScoreboard)
        {
            SavedScores.Scores.Add(scoreboardEntryData);
        }

        //check for more than max
        if(SavedScores.Scores.Count > MaxScoreboard)
        {
            SavedScores.Scores.RemoveRange(MaxScoreboard, SavedScores.Scores.Count - MaxScoreboard);
        }

        UpdateUI(SavedScores);
        SaveScores(SavedScores);
    }

    //for test adding score
    [ContextMenu("Add Test Entry")]
    public void AddEntry()
    {
        AddEntry(test);
    }

    //test AddEntry from UI_Name
    public InputField EnterNameSlot;

    public void Update()
    {
        //temp adding score part
        if (Input.GetKeyDown("h"))
        {
            AddScore();
        }
    }
    public void AddScore()
    {
        print("Add!");
        test.InputScore += 10;
    }

    //need to select "On End Edit" event in Inputfield and also select method that is "Dynamic String"***************************
    public void EnterName(string name)
    {
        test.InputName = name;
        test.InputScore = PlayerPrefs.GetInt("score");
        print("name = " + test.InputName);
        print("name = " + test.InputScore);
    }

    public GameObject EnterNameSlotUI;
    public GameObject ScoreboardUI;

    public void showEnterNameUI()
    {
        EnterNameSlotUI.SetActive(true);
        ScoreboardUI.SetActive(false);
    }

    public void hideEnterNameUI()
    {
        EnterNameSlotUI.SetActive(false);
        ScoreboardUI.SetActive(true);
    }

}
