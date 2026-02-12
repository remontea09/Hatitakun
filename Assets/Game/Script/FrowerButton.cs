using UnityEngine;

public class FlowerButton : MonoBehaviour
{
    [Header("花データ")]
    [TextArea(3, 5)]
    public string description;

    public Sprite flowerSprite;

    [Header("参照先")]
    public FlowerDescriptionPanel descriptionPanel;
    public FlowerPotCharacter flowerPot;

    public void OnClick()
    {
        // 説明文表示
        descriptionPanel.Show(description);

        // 植木鉢に花を咲かせる
        flowerPot.Bloom(flowerSprite);
    }

}
