using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private HatitaController hatitakun;
    [SerializeField] private Goal goal;
    [SerializeField] private GameObject goalPanel;
    public GameObject gameOverUI;


    private void Awake()
    {
        Application.targetFrameRate = 60;
        goalPanel.SetActive(false);
        goal.onGoal += OnGoal;
    }


    private void OnGoal()
    {
        goalPanel.SetActive(true);
        hatitakun.ChangeIsMove(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;  // ÉQÅ[ÉÄÇé~ÇﬂÇÈ
        hatitakun.ChangeIsMove(false);
        gameOverUI.SetActive(true); // âÊñ Çï\é¶
    }

}
