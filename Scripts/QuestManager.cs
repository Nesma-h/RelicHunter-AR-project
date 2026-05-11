using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [Header("UI References")]
    public GameObject infoPanel;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public TMP_Text eraText;
    public TMP_Text progressText;
    public Image iconImage;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip collectSound;
    public AudioClip victorySound;

    [HideInInspector] public RelicInteraction currentRelic;
    private int collectedCount = 0;
    private int totalRelics = 6;

    void Awake() { Instance = this; }

    public void ShowRelicUI(RelicData data)
    {
        if (infoPanel != null)
        {
            nameText.text = data.relicNameArabic;
            descriptionText.text = data.description;
            eraText.text = "العصر: " + data.era;
            if (iconImage != null) iconImage.sprite = data.relicIcon;
            infoPanel.SetActive(true);
        }
    }

    public void PlayNarration()
    {
        if (currentRelic != null && currentRelic.data.narrationClip != null)
        {
            audioSource.Stop();
            audioSource.clip = currentRelic.data.narrationClip;
            audioSource.Play();
        }
    }

    public void OnRelicCollected()
    {
        if (currentRelic != null)
        {
            // وقفي الـ Narration لو شغال ✅
            audioSource.Stop();

            if (collectSound != null) audioSource.PlayOneShot(collectSound);
            currentRelic.Collect();
            collectedCount++;
            progressText.text = collectedCount + " / " + totalRelics + " Items";
            infoPanel.SetActive(false);

            if (collectedCount >= totalRelics)
            {
                if (victorySound != null) audioSource.PlayOneShot(victorySound);
                Invoke("GoToNextScene", 2.5f);
            }
        }
    }

    // ✅ فانكشن جديدة للرجوع للـ Menu
    public void GoToMenuScene()
    {
        // وقفي الصوت لو شغال
        audioSource.Stop();
        SceneManager.LoadScene("MenuScene");
    }

    void GoToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}