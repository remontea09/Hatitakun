using UnityEngine;
using UnityEngine.Rendering;
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
            SkinTypeSelect(index);
        }
    }

    private void SkinTypeSelect(int index)
    {
        SkinType type = index switch
        {
            0 => SkinType.normal,
            2 => SkinType.angel,
            3 => SkinType.devil,
            4 => SkinType.cat,
            5 => SkinType.hero,
            _ => SkinType.normal,
        };

        SkinService.Instance.SetSkin(type);
    }
}