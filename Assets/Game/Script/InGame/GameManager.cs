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
    private float time = 0;

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
        time += Time.deltaTime;
        int intTime = (int)time;
        string toString = intTime.ToString();
        timeText.text = toString;

        if(time > 60)
        {
            GameOver();
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
