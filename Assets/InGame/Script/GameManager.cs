using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private HatitaController hatitakun;
    [SerializeField] private Goal goal;
    [SerializeField] private GameObject goalPanel;
    [SerializeField] private PlayerDeath playerDeth;
    public GameObject gameOverUI;
    public static GameManager Instance;



    private void Awake()
    {
        Application.targetFrameRate = 60;
        goalPanel.SetActive(false);
        goal.onGoal += OnGoal;
        playerDeth.onGameOver += GameOver;
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

    public void Restart()
    {
        Time.timeScale = 1f; // éûä‘Çå≥Ç…ñﬂÇ∑
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
