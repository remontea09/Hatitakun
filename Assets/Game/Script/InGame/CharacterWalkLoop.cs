using UnityEngine;

public class CharacterWalkRandomJump : MonoBehaviour
{
    [Header("歩き設定")]
    public float speed = 100f;
    public float startX = -500f;
    public float endX = 500f;

    [Header("ジャンプ設定")]
    public float jumpHeight = 20f;
    public float jumpDuration = 0.2f;
    public float jumpChance = 0.2f; // 1フレームでジャンプする確率
    public float jumpCooldown = 1f; // 最低間隔（秒）

    RectTransform rect;
    Vector2 basePos;

    bool isJumping = false;
    float jumpTimer = 0f;
    float cooldownTimer = 0f;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        basePos = rect.anchoredPosition;
        basePos.x = startX;
        rect.anchoredPosition = basePos;
    }

    void Update()
    {
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
                isJumping = false; // ジャンプ終了
            }
        }

        rect.anchoredPosition = basePos + new Vector2(0, yOffset);
    }
}
