using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager Instance { get; private set; }

    public AudioClip ballBounceSound;    // Sonido para el rebote de la bola
    public AudioSource effectsSource;

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

    public void PlayBallBounceSound()
    {
        effectsSource.PlayOneShot(ballBounceSound);
    }
}
