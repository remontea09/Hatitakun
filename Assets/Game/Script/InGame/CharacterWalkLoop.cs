using UnityEngine;

public class CharacterWalkRandomJump : MonoBehaviour
{
    [Header("歩き設定")]
    public float speed = 100f;         // 移動速度(px/秒)
    public float startX = -500f;       // 左端スタート位置
    public float endX = 500f;          // 右端終了位置

    [Header("ジャンプ設定")]
    public float jumpHeight = 20f;     // ジャンプ高さ(px)
    public float jumpDuration = 0.2f;  // 上昇→下降秒数
    public float jumpChance = 0.2f;    // 1フレームでジャンプする確率
    public float jumpCooldown = 1f;    // ジャンプ間隔の最低秒数

    RectTransform rect;
    Vector2 basePos;

    bool isJumping = false;
    float jumpTimer = 0f;
    float cooldownTimer = 0f;

    void OnEnable()
    {
        rect = GetComponent<RectTransform>();
        basePos = rect.anchoredPosition;
        basePos.x = startX;
        rect.anchoredPosition = basePos;

        // 初期化
        isJumping = false;
        jumpTimer = 0f;
        cooldownTimer = 0f;
    }

    void Update()
    {
        // タイトルロゴが終わるまで待つ
        if (!TitleLogoDon.IsFinished)
            return;

        float dt = Time.deltaTime;

        // -------------------
        // 歩き処理
        // -------------------
        basePos.x += speed * dt;
        if (basePos.x > endX) basePos.x = startX;

        // -------------------
        // ランダムジャンプ判定
        // -------------------
        cooldownTimer -= dt;
        if (!isJumping && cooldownTimer <= 0f && Random.value < jumpChance)
        {
            isJumping = true;
            jumpTimer = 0f;
            cooldownTimer = jumpCooldown;
        }

        // -------------------
        // ジャンプ処理
        // -------------------
        float yOffset = 0f;
        if (isJumping)
        {
            jumpTimer += dt;
            float t = Mathf.Clamp01(jumpTimer / jumpDuration);
            yOffset = Mathf.Sin(t * Mathf.PI) * jumpHeight;

            if (t >= 1f)
            {
                isJumping = false;
            }
        }

        rect.anchoredPosition = basePos + new Vector2(0, yOffset);
    }
}
