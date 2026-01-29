using TMPro;
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
    [SerializeField] private GameObject howToPlayButton;
    [SerializeField] private GameObject pauseButton;
    public GameObject gameOverUI;

    [SerializeField] private TextMeshProUGUI timeText;
    private float gameOverTime = 60;

    private void Awake()
    {
        Time.timeScale = 1f;
        Application.targetFrameRate = 60;
        goalPanel.SetActive(false);
        goal.onGoal += OnGoal;
        playerGrowth.onGameEnd += GameOver;
        playerDeth.onGameOver += GameOver; 
    }

    private void Update()
    {
        if(gameOverTime >= 0)
        {
            gameOverTime -= Time.deltaTime;
            int intTime = (int)gameOverTime;
            string toString = intTime.ToString();
            timeText.text = toString;
        }

        if(gameOverTime < 0)
        {
            playerGrowth.PlayDeadSE();
        }
    }

    private void OnGoal()
    {
        goalPanel.SetActive(true);
        hatitakun.ChangeIsMove(false);
        int level = playerGrowth.CastLevelToInt();
        goalManager.OnClear(level);
        howToPlayButton.SetActive(false);
        pauseButton.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;  // ゲームを止める
        hatitakun.ChangeIsMove(false);
        gameOverUI.SetActive(true); // 画面を表示
        howToPlayButton.SetActive(false);
        pauseButton.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f; // 時間を元に戻す
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
