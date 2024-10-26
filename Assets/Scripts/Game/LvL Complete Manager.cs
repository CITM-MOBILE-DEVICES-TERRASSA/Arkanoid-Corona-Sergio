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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void ShowLevelCompletePanel()
    {
        levelCompletePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadNextLevel()
    {
        levelCompletePanel.SetActive(false);
        Time.timeScale = 1;

        int nextLevelIndex = (SceneManager.GetActiveScene().buildIndex + 1) % 2;

        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
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
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
