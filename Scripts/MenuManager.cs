using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    // --- السطرين اللي ضفناهم عشان التصليح ---
    public static MenuManager Instance;

    void Awake()
    {
        Instance = this;
    }
    // ---------------------------------------

    [Header("--- Panels ---")]
    public GameObject instructionsPanel;

    [Header("--- Buttons ---")]
    public Button playButton;
    public Button instructionsButton;
    public Button closeInstructionsButton;
    public Button quitButton;

    [Header("--- Audio ---")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip menuMusic;
    public AudioClip buttonClickSound;

    void Start()
    {
        // شغلي الموسيقى
        if (menuMusic != null)
        {
            musicSource.clip = menuMusic;
            musicSource.loop = true;
            musicSource.volume = 0.5f;
            musicSource.Play();
        }

        // تأكدي الـ Panel مخفي
        if (instructionsPanel != null)
            instructionsPanel.SetActive(false);

        // ربط الأزرار بالفانكشنز
        if (playButton != null) playButton.onClick.AddListener(OnPlayClicked);
        if (instructionsButton != null) instructionsButton.onClick.AddListener(OnInstructionsClicked);
        if (closeInstructionsButton != null) closeInstructionsButton.onClick.AddListener(OnCloseInstructions);
        if (quitButton != null) quitButton.onClick.AddListener(OnQuitClicked);
    }

    void PlayClickSound()
    {
        if (buttonClickSound != null && sfxSource != null)
            sfxSource.PlayOneShot(buttonClickSound);
    }

    public void OnPlayClicked()
    {
        PlayClickSound();
        SceneManager.LoadScene("GameScene");
    }

    // ضفت الفانكشن دي عشان لو زرار الـ Back في السين التاني محتاجها
    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene"); // تأكدي إن اسم سين المنيو عندك كده بالظبط
    }

    public void OnInstructionsClicked()
    {
        PlayClickSound();
        if (instructionsPanel != null)
            instructionsPanel.SetActive(true);
    }

    public void OnCloseInstructions()
    {
        PlayClickSound();
        if (instructionsPanel != null)
            instructionsPanel.SetActive(false);
    }

    public void OnQuitClicked()
    {
        PlayClickSound();
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}