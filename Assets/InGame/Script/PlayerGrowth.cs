using UnityEngine;
using System.Collections;
using System;

public class PlayerGrowth : MonoBehaviour
{
    public enum GrowthLevel { Level1, Level2, Level3, Level4, Level5, Level6 }
    public GrowthLevel currentLevel = GrowthLevel.Level1;

    [Header("ステータス")]
    public float[] moveSpeedByLevel = { 3f, 4f, 5f, 6f, 7f };
    public float[] jumpForceByLevel = { 5f, 6f, 6.5f, 7f, 8f };

    [Header("成長ごとのPrefab（Lv1〜Lv6）")]
    public GameObject[] sproutPrefabs = new GameObject[6]; // Lv1〜Lv6

    [Header("芽の表示位置")]
    public Transform sproutSpawnPoint;

    private GameObject currentSprout;
    private Coroutine blinkCoroutine;

    [Header("Level6 特殊演出")]
    public GameObject explosionPrefab; // 爆発エフェクト
    private bool level6Triggered = false;

    public event Action onGameEnd;

    void Start()
    {
        UpdateSprout();
    }

    // 雨に当たったときに呼ぶ
    public void Grow()
    {
        // レベルアップ（Level6 を超えない）
        if (currentLevel < GrowthLevel.Level6)
        {
            currentLevel++;
            UpdateSprout();
        }

        // Level6到達時の特別演出（1回だけ）
        if (currentLevel == GrowthLevel.Level6 && !level6Triggered)
        {
            level6Triggered = true;
            StartCoroutine(Level6Sequence());
        }
    }

    IEnumerator Level6Sequence()
    {
        // 爆発エフェクト生成
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, sproutSpawnPoint.position, Quaternion.identity);
        }

        // 少し待つ（2秒）
        yield return new WaitForSeconds(2f);

        // ゲーム終了イベント
        onGameEnd?.Invoke();
    }

    IEnumerator BlinkAnimation(GameObject obj, int blinkCount = 3, float blinkSpeed = 0.2f)
    {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr == null) yield break;

        for (int i = 0; i < blinkCount; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(blinkSpeed);
            sr.enabled = true;
            yield return new WaitForSeconds(blinkSpeed);
        }
    }

    void UpdateSprout()
    {
        // 前のコルーチンを停止
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
        }

        // 前のスプラウトを削除
        if (currentSprout != null)
        {
            Destroy(currentSprout);
        }

        int lv = (int)currentLevel;

        // 配列の範囲チェック
        if (lv >= 0 && lv < sproutPrefabs.Length)
        {
            GameObject prefab = sproutPrefabs[lv];
            if (prefab != null)
            {
                currentSprout = Instantiate(prefab, sproutSpawnPoint.position, Quaternion.identity);
                currentSprout.transform.SetParent(sproutSpawnPoint);

                // BlinkAnimation を開始
                blinkCoroutine = StartCoroutine(BlinkAnimation(currentSprout, 3, 0.2f));
            }
        }
    }

    public int CastLevelToInt()
    {
        return Mathf.Clamp((int)currentLevel + 1, 1, 6); // Level1=1, Level6=6
    }
}
