using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    void OnEnable()
    {
        LifeManager.OnLivesChange += UpdateLives;
        ScoreManager.OnScoreChange += UpdateScoreUI;
    }

    void Start()
    {
        UpdateLives(LifeManager.Instance.Lives);
        UpdateScoreUI(ScoreManager.Instance.Score);
        highScoreText.text = "High Score: " + ScoreManager.Instance.HighScore;
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    public void UpdateScoreUI(int score)
    {
        scoreText.text = "Score: " + score;
    }

    void OnDisable()
    {
        LifeManager.OnLivesChange -= UpdateLives;
        ScoreManager.OnScoreChange -= UpdateScoreUI;

    }
}

