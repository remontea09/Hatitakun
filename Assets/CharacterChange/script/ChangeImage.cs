using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image targetImage;      // 左の枠の Image
    public Sprite[] sprites;       // 切り替える画像たち（4枚）

    // ボタンからこの関数に index を送る
    public void ChangeSprite(int index)
    {
        if (index >= 0 && index < sprites.Length)
        {
            targetImage.sprite = sprites[index];
        }
    }
}