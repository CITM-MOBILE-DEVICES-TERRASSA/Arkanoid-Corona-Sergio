using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int totalBricks;
    private int destroyedBricks;

    void Awake()
    {
        // Asegurarse de que solo haya una instancia de GameController
        if (FindObjectsOfType<GameController>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
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
        UpdateBrickCount();
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
            LoadNextLevel(); 
        }
    }

    void LoadNextLevel()
    {
  
        int nextLevelIndex = (SceneManager.GetActiveScene().buildIndex + 1) % 2;
        SceneManager.LoadScene(nextLevelIndex);
    }

    public void GameOver()
    {
        Debug.Log("Game Over! Restarting level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
