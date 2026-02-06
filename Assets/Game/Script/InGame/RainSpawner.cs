using UnityEngine;
using System.Collections.Generic;

public class RainSpawner : MonoBehaviour
{
    [Header("雨のPrefab")]
    public GameObject rainPrefab;

    [Header("生成範囲（X方向の幅）")]
    public float spawnRangeX = 4f; // プレイヤーの周りの幅

    [Header("雨の生成間隔")]
    public float spawnInterval = 0.2f;

    [Header("雨の落ちる高さ")]
    public float spawnHeight = 6f;

    [Header("プレイヤー参照（Inspectorで割り当て）")]
    public Transform player;

    private float timer = 0f;
    private bool isSpawning = true;

    private List<GameObject> rainList = new List<GameObject>();

    private void Start()
    {
        SkinType skinType;
        skinType = SkinService.Instance.GetSkinType();
        if(skinType == SkinType.rain)
        {
            spawnInterval = 0.15f;
            spawnRangeX = 5f;
        }
    }

    void Update()
    {
        if (!isSpawning) return;
        if (player == null) return; // プレイヤー未設定なら何もしない

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRain();
            timer = 0f;
        }
    }

    void SpawnRain()
    {
        // プレイヤー位置を基準にランダムXを生成
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(player.position.x + randomX, player.position.y + spawnHeight, 0);

        GameObject rain = Instantiate(rainPrefab, spawnPos, Quaternion.identity);

        rainList.Add(rain);
    }

    public void StopSpawning()
    {
        isSpawning = false;

        foreach (GameObject rain in rainList)
        {
            if (rain != null) Destroy(rain);
        }

        rainList.Clear();
    }
}
