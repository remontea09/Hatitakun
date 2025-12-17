using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseUI;  // É|Å[ÉYâÊñ UI

    private bool isPaused = false;

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseUI.SetActive(false);
        }
    }
}
