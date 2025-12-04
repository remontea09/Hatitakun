using UnityEngine;

public class RainSpawner : MonoBehaviour
{
    [Header("‰J‚ÌPrefab")]
    public GameObject rainPrefab;

    [Header("¶¬”ÍˆÍiX•ûŒü‚Ì•j")]
    public float spawnRangeX = 8f;

    [Header("‰J‚Ì¶¬ŠÔŠu")]
    public float spawnInterval = 0.2f;

    [Header("‰J‚Ì—‚¿‚é‚‚³")]
    public float spawnHeight = 6f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRain();
            timer = 0f;
        }
    }

    void SpawnRain()
    {
        // ƒ‰ƒ“ƒ_ƒ€‚ÈXˆÊ’u
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);

        // ¶¬ˆÊ’u
        Vector3 spawnPos = new Vector3(randomX, spawnHeight, 0);

        // ‰JPrefab¶¬
        Instantiate(rainPrefab, spawnPos, Quaternion.identity);
    }
}