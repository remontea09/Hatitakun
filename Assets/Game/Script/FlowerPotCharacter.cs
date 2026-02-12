using UnityEngine;
using UnityEngine.UI;

public class FlowerPotCharacter : MonoBehaviour
{
    [Header("咲かせる花")]
    public Image flowerImage;

    // 最初に非表示にする
    void Start()
    {
        flowerImage.enabled = false;
    }

    // ボタン押したときに花を表示
    public void Bloom(Sprite flowerSprite)
    {
        flowerImage.sprite = flowerSprite;
        flowerImage.enabled = true;  // 表示
    }

    // 消したいとき
    public void Clear()
    {
        flowerImage.enabled = false; // 非表示
    }
}
