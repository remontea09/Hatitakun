using TMPro;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;

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
