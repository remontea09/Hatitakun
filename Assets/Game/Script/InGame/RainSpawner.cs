using UnityEngine;
using System.Collections.Generic; // List‚ğg‚¤‚½‚ß

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
    private bool isSpawning = true;

    // ¶¬‚µ‚½‰J‚ğŠÇ—‚·‚éƒŠƒXƒg
    private List<GameObject> rainList = new List<GameObject>();

    void Update()
    {
        if (!isSpawning) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRain();
            timer = 0f;
        }
    }

    void SpawnRain()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(randomX, spawnHeight, 0);
        GameObject rain = Instantiate(rainPrefab, spawnPos, Quaternion.identity);

        // ¶¬‚µ‚½‰J‚ğƒŠƒXƒg‚É’Ç‰Á
        rainList.Add(rain);
    }

    // ‰J‚Ì¶¬‚ğ~‚ß‚é + ‚·‚Å‚É‚ ‚é‰J‚àíœ
    public void StopSpawning()
    {
        isSpawning = false;

        // ‚·‚Å‚É¶¬‚³‚ê‚Ä‚¢‚é‰J‚ğ‘S•”íœ
        foreach (GameObject rain in rainList)
        {
            if (rain != null) Destroy(rain);
        }

        // ƒŠƒXƒg‚àƒNƒŠƒA
        rainList.Clear();
    }
}
