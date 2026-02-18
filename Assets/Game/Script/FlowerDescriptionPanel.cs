using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlowerDescriptionPanel : MonoBehaviour
{
    public TMP_Text descriptionText;
    // TextMeshProÇ»ÇÁ TMP_Text Ç…ïœçX

    void Awake()
    {
        Clear();
    }

    public void Show(string message)
    {
        descriptionText.text = message;
    }

    public void Clear()
    {
        descriptionText.text = "";
    }
}
