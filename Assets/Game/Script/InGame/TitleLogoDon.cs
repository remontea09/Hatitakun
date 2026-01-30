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

    void Start()
    {
        IsFinished = false;
        basePos = transform.localPosition;
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        transform.localScale = Vector3.one * startScale;

        // ÉhÉìÅI
        yield return ScaleTo(targetScale, popTime);

        // è≠ÇµñﬂÇÈ
        yield return ScaleTo(endScale, settleTime);

        // óhÇÍ
        yield return Shake();

        IsFinished = true;
    }

    IEnumerator ScaleTo(float target, float time)
    {
        Vector3 start = transform.localScale;
        Vector3 end = Vector3.one * target;
        float t = 0f;

        while (t < time)
        {
            t += Time.deltaTime;
            float rate = t / time;
            transform.localScale = Vector3.Lerp(start, end, rate);
            yield return null;
        }

        transform.localScale = end;
    }

    IEnumerator Shake()
    {
        float t = 0f;

        while (t < shakeDuration)
        {
            t += Time.deltaTime;
            float x = Mathf.Sin(t * 50f) * shakePower;
            transform.localPosition = basePos + new Vector3(x, 0, 0);
            yield return null;
        }

        transform.localPosition = basePos;
    }
}
