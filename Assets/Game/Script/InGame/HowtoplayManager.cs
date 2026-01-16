using UnityEngine;
using UnityEngine.UI;

public class HowToplayManager : MonoBehaviour
{
    public GameObject howToPlayUI;

    public Image howToPlayImage;      // 表示用Image
    public Sprite[] howToPlaySprites; // 3枚の画像

    private bool isOpen = false;
    private int currentIndex = 0;

    public void ToggleHowToPlay()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            Time.timeScale = 0f;
            howToPlayUI.SetActive(true);
            ShowImage(0); // 最初のページ
        }
        else
        {
            Time.timeScale = 1f;
            howToPlayUI.SetActive(false);
        }
    }

    public void NextPage()
    {
        currentIndex++;
        if (currentIndex >= howToPlaySprites.Length)
        {
            currentIndex = howToPlaySprites.Length - 1;
        }
        ShowImage(currentIndex);
    }

    public void PrevPage()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = 0;
        }
        ShowImage(currentIndex);
    }

    private void ShowImage(int index)
    {
        howToPlayImage.sprite = howToPlaySprites[index];
    }
}
