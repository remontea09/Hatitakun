using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image targetImage;      // 左の枠の Image
    public Sprite[] sprites;       // 切り替える画像たち（4枚）

    [SerializeField] private Button backButton;

    private void Awake()
    {
        backButton.onClick.AddListener(() => SceneManager.LoadScene("HomeScene"));
    }

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
            1 => SkinType.angel,
            2=> SkinType.devil,
            3 => SkinType.cat,
            4 => SkinType.hero,
            _ => SkinType.normal,
        };

        SkinService.Instance.SetSkinType(type);
    }
}