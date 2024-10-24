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
    // Start is called before the first frame update
    void Start()
    {
        LifeManager.OnLivesChange += UpdateLives;
        ScoreManager.OnScoreChange += UpdateScoreUI;

        UpdateLives(3);

        UpdateScoreUI(ScoreManager.Instance.Score);
        highScoreText.text = "High Score: " + ScoreManager.Instance.HighScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    public void UpdateScoreUI(int score)
    {
        scoreText.text = "Score: " + score;
    }

    void OnDestroy()
    {
        LifeManager.OnLivesChange -= UpdateLives;
        ScoreManager.OnScoreChange -= UpdateScoreUI;

    }
}

