using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonShakeOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("震え設定")]
    public float shakePower = 5f;    // ピクセル単位の震え幅
    public float shakeSpeed = 50f;   // 震えの速さ

    RectTransform rect;
    Vector2 basePos;
    bool isHover = false;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        basePos = rect.anchoredPosition;
    }

    void Update()
    {
        if (isHover)
        {
            float xOffset = Mathf.Sin(Time.time * shakeSpeed) * shakePower;
            float yOffset = Mathf.Cos(Time.time * shakeSpeed) * shakePower * 0.5f; // 少し縦も揺らす
            rect.anchoredPosition = basePos + new Vector2(xOffset, yOffset);
        }
        else
        {
            rect.anchoredPosition = Vector2.Lerp(rect.anchoredPosition, basePos, Time.deltaTime * 10f);
        }
    }

    // マウスが乗った時
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHover = true;
    }

    // マウスが離れた時
    public void OnPointerExit(PointerEventData eventData)
    {
        isHover = false;
    }
}
