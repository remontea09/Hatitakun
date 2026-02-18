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
    public float jumpCooldown = 1f;

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

        isJumping = false;
        jumpTimer = 0f;
        cooldownTimer = 0f;
    }

    void Update()
    {
        if (!TitleLogoDon.IsFinished)
            return;

        float dt = Time.deltaTime;

        // 歩き
        basePos.x += speed * dt;
        if (basePos.x > endX) basePos.x = startX;

        // クリックジャンプ
        cooldownTimer -= dt;
        if (!isJumping && cooldownTimer <= 0f && Input.GetMouseButtonDown(0))
        {
            isJumping = true;
            jumpTimer = 0f;
            cooldownTimer = jumpCooldown;
        }

        // ジャンプ処理
        float yOffset = 0f;
        if (isJumping)
        {
            jumpTimer += dt;
            float t = Mathf.Clamp01(jumpTimer / jumpDuration);
            yOffset = Mathf.Sin(t * Mathf.PI) * jumpHeight;

            if (t >= 1f)
                isJumping = false;
        }

        rect.anchoredPosition = basePos + new Vector2(0, yOffset);
    }
}
