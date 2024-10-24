using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }//Singleton
    public int Score { get; private set; }
    public int HighScore { get; private set; }
    public string PlayerName { get; private set; }

    public static event System.Action<int> OnScoreChange;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadPlayerData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        Score += points;
        OnScoreChange?.Invoke(Score);

        if (Score > HighScore)
        {
            HighScore = Score;
            SavePlayerData();
        }
    }
    public void ResetScore()
    {
        Score = 0;
        OnScoreChange?.Invoke(Score);
    }

    private void LoadPlayerData()
    {
        PlayerData data = JsonDataManager.LoadData();
        HighScore = data.highScore;
        PlayerName = data.playerName;
    }

    private void SavePlayerData()
    {
        Debug.Log("Saving player data..."); // Añadir esto para depurar
        PlayerData data = new PlayerData
        {
            playerName = PlayerName,
            highScore = HighScore
        };
        JsonDataManager.SaveData(data);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
