using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        LifeManager.OnLivesChange += UpdateLives;
        UpdateLives(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives; // Actualizar el texto de las vidas
    }

    void OnDestroy()
    {
        // Desregistrar suscripciones para evitar fugas de memoria
        LifeManager.OnLivesChange -= UpdateLives;
    }
}

