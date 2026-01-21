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
    public GameObject[] sproutPrefabs = new GameObject[6];

    [Header("芽の表示位置")]
    public Transform sproutSpawnPoint;

    [Header("プレイヤー画像（Lv6用：左右）")]
    public SpriteRenderer playerRenderer;
    public Sprite level6SpriteRight;   // 右向き
    public Sprite level6SpriteLeft;    // 左向き

    [Header("成長時の効果音")]
    public AudioSource audioSource;
    public AudioClip growSE;
    public AudioClip level6SE;

    [Header("ダメージ時点滅")]
    public float damageBlinkDuration = 1.0f;
    public float damageBlinkInterval = 0.1f;

    private Coroutine playerBlinkCoroutine;

    public event Action onGameEnd;

    private GameObject currentSprout;
    private Coroutine blinkCoroutine;
    private bool gameOverTriggered = false;

    [SerializeField] private HatitaController hatitaController;

    // プレイヤーの向き（外部の移動スクリプトから更新するのがベスト）
    public bool isFacingRight = true;

    [SerializeField] private AudioSource bgmSource;

    void Start()
    {
        hatitaController = this.gameObject.GetComponent<HatitaController>();
        UpdateSprout();
    }

    // 雨に当たったときに呼ぶ
    public void Grow()
    {
        if (currentLevel < GrowthLevel.Level6)
        {
            currentLevel++;
            UpdateSprout();
            //UpdatePlayerSpriteForLevel6();
            PlayGrowSE();
            if (SkinService.Instance.skinType == SkinType.angel)
            {
                hatitaController.UpJumpPower();
            }
            else if(SkinService.Instance.skinType == SkinType.devil)
            {
                hatitaController.DownJumpPower();
            }

            if (currentLevel == GrowthLevel.Level6 && !gameOverTriggered)
            {
                StartCoroutine(Level6GameOverSequence());
            }
        }
    }

    /// <summary>
    /// Lv6時にだけプレイヤー画像を左右向きに応じて変更
    /// </summary>
    //void UpdatePlayerSpriteForLevel6()
    //{
    //    if (currentLevel != GrowthLevel.Level6) return;

    //    if (playerRenderer == null) return;

    //    if (isFacingRight)
    //    {
    //        if (level6SpriteRight != null)
    //            playerRenderer.sprite = level6SpriteRight;
    //    }
    //    else
    //    {
    //        if (level6SpriteLeft != null)
    //            playerRenderer.sprite = level6SpriteLeft;
    //    }
    //}

    /// <summary>
    /// Lv6専用SE → 終わってからゲームオーバー
    /// </summary>
    IEnumerator Level6GameOverSequence()
    {
        gameOverTriggered = true;

        // BGMを止める
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }

        float waitTime = (level6SE != null) ? level6SE.length : 0f;
        yield return new WaitForSeconds(waitTime);

        onGameEnd?.Invoke();
    }


    void PlayGrowSE()
    {
        if (audioSource == null) return;

        if (currentLevel == GrowthLevel.Level6)
        {
            if (level6SE != null)
                audioSource.PlayOneShot(level6SE);
        }
        else
        {
            if (growSE != null)
                audioSource.PlayOneShot(growSE);
        }
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
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
        }

        if (currentSprout != null)
        {
            Destroy(currentSprout);
        }

        int lv = (int)currentLevel;

        if (lv >= 0 && lv < sproutPrefabs.Length)
        {
            GameObject prefab = sproutPrefabs[lv];
            if (prefab != null)
            {
                currentSprout = Instantiate(prefab, sproutSpawnPoint.position, Quaternion.identity);
                currentSprout.transform.SetParent(sproutSpawnPoint);

                blinkCoroutine = StartCoroutine(BlinkAnimation(currentSprout, 3, 0.2f));
            }
        }
    }

    public int CastLevelToInt()
    {
        return Mathf.Clamp((int)currentLevel + 1, 1, 6);
    }

    public void BlinkPlayer()
    {
        if (playerRenderer == null) return;

        if (playerBlinkCoroutine != null)
            StopCoroutine(playerBlinkCoroutine);

        playerBlinkCoroutine = StartCoroutine(PlayerBlinkCoroutine());
    }

    IEnumerator PlayerBlinkCoroutine()
    {
        float timer = 0f;

        while (timer < damageBlinkDuration)
        {
            playerRenderer.enabled = false;
            yield return new WaitForSeconds(damageBlinkInterval);

            playerRenderer.enabled = true;
            yield return new WaitForSeconds(damageBlinkInterval);

            timer += damageBlinkInterval * 2f;
        }

        playerRenderer.enabled = true;
    }
}
