using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System;


public class GameController : MonoBehaviour
{
    private int totalBricks;
    private int destroyedBricks;
    public static GameController Instance { get; private set; } // Singleton
    public int CurrentLevelIndex { get; private set; }


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            return;
        }
        CurrentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        UpdateBrickCount();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "MainMenu" && scene.name != "GameOver")
        {
            CurrentLevelIndex = scene.buildIndex;
            UpdateBrickCount();
        }
    }

    private void UpdateBrickCount()
    {
        totalBricks = FindObjectsOfType<BlockController>().Length;
        destroyedBricks = 0;
        Debug.Log("Total bricks in this level: " + totalBricks);
    }

    public void BrickDestroyed()
    {
        destroyedBricks++;
        totalBricks--;
        Debug.Log("Bricks remaining: " + totalBricks);

        if (totalBricks <= 0)
        {
            LevelCompleteManager.Instance?.ShowLevelCompletePanel();
        }
    }

    public void StartGame()
    {
        LifeManager.Instance.ResetLives();
        ScoreManager.Instance.ResetScore();
        Debug.Log("StartGame button pressed.");
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        Debug.Log("Game Over! Returning to Game Over Screen...");
        SceneManager.LoadScene("GameOver");
    }
}
