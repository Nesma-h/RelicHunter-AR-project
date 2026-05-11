using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryManager : MonoBehaviour
{
    [Header("--- Audio ---")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip victoryMusic;
    public AudioClip buttonClickSound;

    [Header("--- Buttons ---")]
    public Button playAgainButton;
    public Button mainMenuButton;

    void Start()
    {
        
        if (victoryMusic != null)
        {
            musicSource.clip = victoryMusic;
            musicSource.loop = true;
            musicSource.volume = 0.6f;
            musicSource.Play();
        }

        playAgainButton.onClick.AddListener(OnPlayAgain);
        mainMenuButton.onClick.AddListener(OnMainMenu);
    }

    void PlayClick()
    {
        if (buttonClickSound != null)
            sfxSource.PlayOneShot(buttonClickSound);
    }

    public void OnPlayAgain()
    {
        PlayClick();
        Invoke(nameof(LoadGame), 0.3f);
    }

    public void OnMainMenu()
    {
        PlayClick();
        Invoke(nameof(LoadMenu), 0.3f);
    }

    void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}