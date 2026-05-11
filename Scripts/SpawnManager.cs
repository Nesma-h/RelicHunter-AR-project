using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    public GameObject[] artifacts;
    public float spawnDistance = 2.0f;
    public float spawnHeight = 0.0f;
    public float spreadRadius = 0.8f;
    private bool hasSpawned = false;
 
void Start()
    {
        // القطع بتظهر تلقائي لما اللعبة تفتح
        Invoke(nameof(SpawnArtifacts), 1.5f);
    }

    void SpawnArtifacts()
    {
        if (hasSpawned) return;
        hasSpawned = true;

        Transform cam = Camera.main.transform;

        for (int i = 0; i < artifacts.Length; i++)
        {
            float angle = (360f / artifacts.Length) * i;
            float rad = angle * Mathf.Deg2Rad;

            Vector3 spawnPos = cam.position
                             + cam.forward * spawnDistance
                             + new Vector3(
                                 Mathf.Cos(rad) * spreadRadius,
                                 spawnHeight,
                                 Mathf.Sin(rad) * spreadRadius
                               );

            GameObject obj = Instantiate(
                artifacts[i],
                spawnPos,
                Quaternion.identity
            );

            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false;
                rb.isKinematic = true;
            }
        }
    }
}