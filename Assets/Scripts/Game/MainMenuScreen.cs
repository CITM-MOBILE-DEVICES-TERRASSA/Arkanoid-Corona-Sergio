using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startGameButton;
    public Button continueButton;
    public Button quitButton;

    void Start()
    {
        if (startGameButton != null)
        {
            startGameButton.onClick.AddListener(OnStartGame);
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(OnQuitGame);
        }

        if (continueButton != null)
        {
            continueButton.onClick.AddListener(OnContinueGame);
            UpdateContinueButton();
        }
    }
    void UpdateContinueButton()
    {
        // Comprobar si hay vidas y puntaje diferentes de cero
        if (LifeManager.Instance.Lives > 0 && ScoreManager.Instance.Score > 0)
        {
            continueButton.gameObject.SetActive(true); // Habilita el bot�n
        }
        else
        {
            continueButton.gameObject.SetActive(false); // Deshabilita el bot�n
        }
    }
    void OnContinueGame()
    {
        Debug.Log("Continue Game Button Clicked");
        int lastLevelIndex = GameController.Instance.CurrentLevelIndex;
        SceneManager.LoadScene(lastLevelIndex);
    }

    void OnStartGame()
    {
        Debug.Log("Start Game Button Clicked");
        GameController.Instance.StartGame(); // Llama al m�todo para iniciar el juego
    }

    void OnQuitGame()
    {
        Debug.Log("Quit Button Clicked");
        Application.Quit(); // Cierra la aplicaci�n
    }
}