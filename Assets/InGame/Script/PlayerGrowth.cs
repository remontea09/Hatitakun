using UnityEngine;
using System.Collections;

public class PlayerGrowth : MonoBehaviour
{
    public enum GrowthLevel { Level1, Level2, Level3, Level4, Level5, Level6 }
    public GrowthLevel currentLevel = GrowthLevel.Level1;

    [Header("ステータス")]
    public float[] moveSpeedByLevel = { 3f, 4f, 5f, 6f, 7f };
    public float[] jumpForceByLevel = { 5f, 6f, 6.5f, 7f, 8f };

    [Header("成長ごとのPrefab（Lv1〜Lv5）")]
    public GameObject[] sproutPrefabs = new GameObject[6]; // 0=Lv1, 1=Lv2, 2=Lv3, 3=Lv4

    [Header("芽の表示位置")]
    public Transform sproutSpawnPoint;

    private GameObject currentSprout;

    [Header("Level6 特殊演出")]
    public GameObject explosionPrefab; // 爆発エフェクト

    //private HatitakunConttoller movement;

    void Start()
    {
        //movement = GetComponent<HatitakunConttoller>();
        //ApplyGrowthStats();  // 初期値設定
        UpdateSprout();
    }

    // 雨に当たったときに呼ぶ
    public void Grow()
    {
        // レベルアップ
        if (currentLevel < GrowthLevel.Level6)
        {
            currentLevel++;
            UpdateSprout();
        }

        // Level6到達時の特別演出
        if (currentLevel == GrowthLevel.Level6)
        {
            StartCoroutine(Level6Sequence());
        }
    }
    IEnumerator Level6Sequence()
    {
        // 1. 爆発エフェクトをプレイヤー位置に生成
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, sproutSpawnPoint.position, Quaternion.identity);
        }

        // 2. 少し待つ（0.5秒～1秒など）
        yield return new WaitForSeconds(2f);

        // 3. ゲームオーバー
        GameManager.Instance.GameOver();
    }



    // 移動速度・ジャンプ力・スプライトの更新
    //void ApplyGrowthStats()
    //{
    //    int lv = (int)currentLevel;

    //    if (movement != null)
    //    {
    //        movement.moveSpeed = moveSpeedByLevel[lv];
    //        movement.jumpForce = jumpForceByLevel[lv];
    //    }
    //}
    IEnumerator BlinkAnimation(GameObject obj, int blinkCount = 3, float blinkSpeed = 0.2f)
    {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr == null) yield break;

        for (int i = 0; i < blinkCount; i++)
        {
            // 非表示
            sr.enabled = false;
            yield return new WaitForSeconds(blinkSpeed);

            // 表示
            sr.enabled = true;
            yield return new WaitForSeconds(blinkSpeed);
        }
    }
    void UpdateSprout()
    {
        // すでにある芽を削除
        if (currentSprout != null)
        {
            Destroy(currentSprout);
        }

        // 今のレベルに対応するPrefabを取得
        int lv = (int)currentLevel;
        GameObject prefab = sproutPrefabs[lv];

        if (prefab != null)
        {
            currentSprout = Instantiate(prefab, sproutSpawnPoint.position, Quaternion.identity);
            currentSprout.transform.SetParent(sproutSpawnPoint);

            StartCoroutine(BlinkAnimation(currentSprout, 3, 0.2f));
        }
    }


}