using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LifeManager : MonoBehaviour
{
    public int lives = 3;
    public Transform ballStartPosition;
    private GameObject ball;
    public int Lives => lives;
    public static event Action<int> OnLivesChange;

    public static LifeManager Instance { get; private set; } // Singleton

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

    // Start is called before the first frame update
    void Start()
    {
        UpdateBallReference();
        UpdateLives();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            LoseLife();
        }
    }
    void LoseLife()
    {
        lives--;

        OnLivesChange?.Invoke(lives);

        if (lives > 0)
        {
            Debug.Log("Resetting the ball...");

            ResetBall();
        }

        else
        {
            Debug.Log("Game Over");
            GameController gameController = FindObjectOfType<GameController>();
            if (gameController != null)
            {
                gameController.GameOver();
            }
        }

    }
    private void ResetBall()
    {
        if (ball != null)
        {
            ball.transform.position = ballStartPosition.position;
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            BallController ballController = ball.GetComponent<BallController>();

            if (ballController != null)
            {
                ballController.ResetBall();
                Debug.Log("BallController ResetBall called successfully.");
            }
            else
            {
                Debug.LogError("BallController not found on ball!");
            }
        }
    }
    public void ResetLives()
    {
        lives = 3; // O el número que desees
        UpdateLives();
        Debug.Log("Lives have been reset to: " + lives);
    }
    private void UpdateLives()
    {
        OnLivesChange?.Invoke(lives);
    }

    public void UpdateBallReference() //Busca ball en la escena actual para asignarle su transform al ballStartPosition
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball != null)
        {
            ballStartPosition = ball.transform;
            //Debug.Log("Ball found and ballStartPosition updated: " + ball.name);
        }
        else
        {
            //Debug.LogWarning("Ball not found! Ensure the Ball object has the 'Ball' tag.");
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateBallReference();
    }
}



