using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteManager : MonoBehaviour
{
    public static LevelCompleteManager Instance { get; private set; }

    [SerializeField] private GameObject levelCompletePanel;

    void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Mantener entre escenas
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void ShowLevelCompletePanel()
    {
        levelCompletePanel.SetActive(true);  // Mostrar el panel
        Time.timeScale = 0;                     // Pausa el juego
    }

    public void LoadNextLevel()
    {
        levelCompletePanel.SetActive(false); // Ocultar el panel al cambiar de nivel
        Time.timeScale = 1;                     // Reanuda el juego

        //int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int nextLevelIndex = (SceneManager.GetActiveScene().buildIndex + 1) % 2; // Esto asume que solo hay 2 niveles

        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex); // Cargar el siguiente nivel
        }
        else
        {
            Debug.Log("Todos los niveles completados. Volviendo al menú principal.");
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void ReturnToMainMenu()
    {
        levelCompletePanel.SetActive(false);
        Time.timeScale = 1;                     // Reanuda el juego
        SceneManager.LoadScene("MainMenu");
    }
}
