using TMPro;
using UnityEngine;

public class ScoreboardEntryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI InputNameText = null;
    [SerializeField] private TextMeshProUGUI InputScoreText = null;

    public void init(ScoreboardEntryData scoreboardEntryData)
    {
        InputNameText.text = scoreboardEntryData.InputName;
        InputScoreText.text = scoreboardEntryData.InputScore.ToString();
    }

}
