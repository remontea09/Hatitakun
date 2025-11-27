using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private HatitaController hatitakun;
    [SerializeField] private Goal goal;
    [SerializeField] private GameObject goalPanel;
    public GameObject gameOverUI;
    public static GameManager Instance;


    private void Awake()
    {
        goalPanel.SetActive(false);
        goal.onGoal += OnGoal;
        Instance = this;
    }


    private void OnGoal()
    {
        goalPanel.SetActive(true);
        hatitakun.ChangeIsMove(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;  // ÉQÅ[ÉÄÇé~ÇﬂÇÈ
        gameOverUI.SetActive(true); // âÊñ Çï\é¶
    }

}
