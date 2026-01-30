using UnityEngine;

public class CharacterBeatBounce : MonoBehaviour
{
    [Header("Beat Settings")]
    public float bpm = 120f;
    public float squatAmount = 0.15f;
    public float smooth = 10f;

    Vector3 baseScale;
    float beatTime;

    void Start()
    {
        baseScale = transform.localScale;
        beatTime = 60f / bpm;
    }

    void Update()
    {
        if (!TitleLogoDon.IsFinished)
            return;

        float t = Mathf.PingPong(Time.time / beatTime, 1f);
        float squat = Mathf.Sin(t * Mathf.PI) * squatAmount;

        Vector3 targetScale = baseScale;
        targetScale.y = baseScale.y * (1f - squat);

        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            Time.deltaTime * smooth
        );
    }
}
