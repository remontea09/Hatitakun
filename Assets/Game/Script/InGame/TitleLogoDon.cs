using UnityEngine;
using System.Collections;

public class TitleLogoDon : MonoBehaviour
{
    public static bool IsFinished { get; private set; }

    public float startScale = 0.3f;
    public float targetScale = 1.2f;
    public float endScale = 1.0f;
    public float popTime = 0.2f;
    public float settleTime = 0.15f;
    public float shakeDuration = 0.25f;
    public float shakePower = 10f;

    Vector3 basePos;

    private Coroutine animCoroutine;

    void OnEnable()
    {
        Time.timeScale = 1f;
        // シーン切り替え後でも必ずアニメーションを再開
        IsFinished = false;
        basePos = transform.localPosition;

        // 既に動いている場合は停止
        if (animCoroutine != null) StopCoroutine(animCoroutine);
        animCoroutine = StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        transform.localScale = Vector3.one * startScale;

        yield return ScaleTo(targetScale, popTime);
        yield return ScaleTo(endScale, settleTime);
        yield return Shake();

        IsFinished = true;
    }

    IEnumerator ScaleTo(float target, float duration)
    {
        Vector3 start = transform.localScale;
        Vector3 end = Vector3.one * target;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(start, end, t / duration);
            yield return null;
        }
        transform.localScale = end;
    }

    IEnumerator Shake()
    {
        float t = 0f;
        Vector3 pos = transform.localPosition;

        while (t < shakeDuration)
        {
            t += Time.deltaTime;
            float offsetX = Random.Range(-shakePower, shakePower);
            float offsetY = Random.Range(-shakePower, shakePower);
            transform.localPosition = pos + new Vector3(offsetX, offsetY, 0);
            yield return null;
        }

        transform.localPosition = pos;
    }
}
