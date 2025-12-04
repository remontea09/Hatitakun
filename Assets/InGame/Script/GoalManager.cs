using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private Button button;

    // 追加：雨生成管理
    [SerializeField] private RainSpawner rainSpawner;

    private void Awake()
    {
        button.onClick.AddListener(() => SceneManager.LoadScene("TitleScene"));
    }

    public void OnClear(int score)
    {
        // 雨を止める
        if (rainSpawner != null)
        {
            rainSpawner.StopSpawning();
        }

        // スコアに応じてテキスト表示
        switch (score)
        {
            case 1:
                countText.text = "Bad...";
                break;
            case 2:
                countText.text = "Okay";
                break;
            case 3:
                countText.text = "Good";
                break;
            case 4:
                countText.text = "Great";
                break;
            case 5:
                countText.text = "Perfect!";
                break;
            case 6:
                countText.text = "Miss...";
                break;
        }
    }
}
