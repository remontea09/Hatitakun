using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private HatitaController hatitakun;
    [SerializeField] private Goal goal;
    [SerializeField] private GameObject goalPanel;
    [SerializeField] private PlayerDeath playerDeth;
    [SerializeField] private PlayerGrowth playerGrowth;
    [SerializeField] private GoalManager goalManager;
    public GameObject gameOverUI;



    private void Awake()
    {
        Application.targetFrameRate = 60;
        goalPanel.SetActive(false);
        goal.onGoal += OnGoal;
        playerGrowth.onGameEnd += GameOver;
        playerDeth.onGameOver += GameOver; 
    }

    private void OnGoal()
    {
        goalPanel.SetActive(true);
        hatitakun.ChangeIsMove(false);
        int level = playerGrowth.CastLevelToInt();
        goalManager.OnClear(level);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;  // ゲームを止める
        hatitakun.ChangeIsMove(false);
        gameOverUI.SetActive(true); // 画面を表示
    }

    public void Restart()
    {
        Time.timeScale = 1f; // 時間を元に戻す
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
