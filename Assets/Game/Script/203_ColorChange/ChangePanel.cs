using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ★追加
using UnityEngine.UI;

public class ChangePanel : MonoBehaviour
{
    [SerializeField] private Image panelImage;
    [SerializeField] private float color_speed = 6f;

    [SerializeField] private RectTransform C_Panel;
    [System.NonSerialized]
    [SerializeField] private Vector2 rectSize;

    [System.NonSerialized]
    [SerializeField] private Vector2 targetSize;
    [SerializeField] private float panel_speed = 2f;
    private float t;

    void Start()
    {
        panelImage = GetComponent<Image>();

        C_Panel = GetComponent<RectTransform>();

        C_Panel.sizeDelta = new Vector2(0, 0);
        targetSize = new Vector2(Screen.width, Screen.height);　//スクリーンサイズを取得
        rectSize = C_Panel.sizeDelta; // サイズ取得


    }

    void Update()
    {
        panelImage.color = Color.Lerp(panelImage.color, new Color(0, 0, 0, 1), color_speed * Time.deltaTime);

        if (t < 1f)
        {
            t += Time.deltaTime * panel_speed;
            C_Panel.sizeDelta = Vector2.Lerp(rectSize, targetSize, t);
        }
    }
}
