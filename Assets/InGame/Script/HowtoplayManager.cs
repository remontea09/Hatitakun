using UnityEngine;

public class HowToplayManager : MonoBehaviour
{
    public GameObject howToPlayUI;
    private bool isOpen = false;

    public void ToggleHowToPlay()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            Time.timeScale = 0f;
            howToPlayUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            howToPlayUI.SetActive(false);
        }
    }
}
