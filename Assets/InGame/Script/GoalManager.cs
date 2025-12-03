using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private Button button;

    private void Awake()
    {
        button.onClick.AddListener(() => SceneManager.LoadScene("TitleScene"));
    }

    public void OnClear(int score)
    {
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
