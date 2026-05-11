using UnityEngine;
using System.Collections;

public class RelicInteraction : MonoBehaviour
{
    public RelicData data;
    private bool isCollected = false;

    public void OnTapped()
    {
        if (isCollected) return;
        StartCoroutine(MoveToCamera());
    }

    IEnumerator MoveToCamera()
    {
        Transform cam = Camera.main.transform;
        Vector3 targetPos = cam.position + cam.forward * 0.7f;

        float elapsed = 0;
        Vector3 startPos = transform.position;

        while (elapsed < 0.8f)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / 0.8f);
            transform.Rotate(Vector3.up, 2);
            elapsed += Time.deltaTime;
            yield return null;
        }

        if (QuestManager.Instance != null)
        {
            QuestManager.Instance.currentRelic = this;
            QuestManager.Instance.ShowRelicUI(data);
        }
    }

    public void Collect()
    {
        isCollected = true;
        StartCoroutine(ShrinkAndDestroy());
    }

    IEnumerator ShrinkAndDestroy()
    {
        float elapsed = 0;
        Vector3 startScale = transform.localScale;
        while (elapsed < 0.5f)
        {
            transform.localScale = Vector3.Lerp(startScale, Vector3.zero, elapsed / 0.5f);
            elapsed += Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}