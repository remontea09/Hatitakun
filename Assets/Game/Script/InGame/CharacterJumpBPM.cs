using UnityEngine;

public class CharacterJumpBPM : MonoBehaviour
{
    [Header("BPM Settings")]
    public float bpm = 120f;          // 曲のBPM
    public float jumpHeight = 20f;    // ジャンプ高さ(px)
    public float jumpDuration = 0.2f; // 上昇→下降にかける秒数
    public AudioSource audioSource;   // BGM

    RectTransform rect;
    Vector2 basePos;
    float secondsPerBeat;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        basePos = rect.anchoredPosition;
        secondsPerBeat = 60f / bpm;
    }

    void Update()
    {
        // ★ロゴ演出が終わるまで待つ
        if (!TitleLogoDon.IsFinished)
            return;

        if (audioSource == null || !audioSource.isPlaying)
            return;

        float songTime = audioSource.time;

        // 拍の頭からの進捗（0～1）
        float beatProgress = (songTime % secondsPerBeat) / jumpDuration;
        float t = Mathf.Clamp01(beatProgress);

        // Sinでジャンプ
        float yOffset = Mathf.Sin(t * Mathf.PI) * jumpHeight;
        rect.anchoredPosition = basePos + new Vector2(0, yOffset);
    }
}
