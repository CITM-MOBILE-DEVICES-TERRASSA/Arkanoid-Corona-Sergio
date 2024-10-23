using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LifeManager : MonoBehaviour
{
    public int lives = 3;
    public Transform ballStartPosition;
    private GameObject ball;
    public int Lives => lives; // Propiedad para acceder a las vidas
    public static event Action<int> OnLivesChange;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        UpdateLives();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            //Para reiniciar la posición de la pelota
            ball.transform.position = ballStartPosition.position;
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            ball.GetComponent<BallController>().ResetBall();
        }
        else
        {
            Debug.Log("Game Over");
            // Aquí puedes implementar la lógica de "Game Over" (reiniciar el juego, mostrar una pantalla de fin, etc.)
        }
    }
    private void UpdateLives()
    {
        OnLivesChange?.Invoke(lives); // Notificar el cambio de vidas
    }
}



