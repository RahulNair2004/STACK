using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private int score;
    private int highestScore;
    private TextMeshProUGUI text;

    private const string HighestScoreKey = "HighestScore";

    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        highestScore = PlayerPrefs.GetInt(HighestScoreKey, 0); // Load highest score from PlayerPrefs
        UpdateScoreText();

        GameManager.OnCubeSpawned += GameManager_OnCubeSpawned;
    }

    private void OnDestroy()
    {
        GameManager.OnCubeSpawned -= GameManager_OnCubeSpawned;
    }

    private void GameManager_OnCubeSpawned()
    {
        score++;
        UpdateScoreText();

        if (score > highestScore)
        {
            highestScore = score;
            PlayerPrefs.SetInt(HighestScoreKey, highestScore); // Save highest score to PlayerPrefs
        }
    }

    private void UpdateScoreText()
    {
        text.text = "Score: " + score + "\t Highest Score: " + highestScore;
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}
