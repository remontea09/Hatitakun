using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private Button button;

    [SerializeField] private RainSpawner rainSpawner;

    [Header("サウンド")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip goalSE;

    // ★ 追加：結果表示用Image
    [Header("結果画像")]
    [SerializeField] private Image resultImage;
    [SerializeField] private Sprite badSprite;
    [SerializeField] private Sprite okaySprite;
    [SerializeField] private Sprite goodSprite;
    [SerializeField] private Sprite greatSprite;
    [SerializeField] private Sprite perfectSprite;
    [SerializeField] private Sprite missSprite;

    private void Awake()
    {
        button.onClick.AddListener(() => SceneManager.LoadScene("StageSelectScene"));
        button.interactable = false;
    }

    public void OnClear(int score)
    {
        if (rainSpawner != null)
        {
            rainSpawner.StopSpawning();
        }

        switch (score)
        {
            case 1:
                countText.text = "Bad...";
                resultImage.sprite = badSprite;
                break;
            case 2:
                countText.text = "Okay";
                resultImage.sprite = okaySprite;
                break;
            case 3:
                countText.text = "Good";
                resultImage.sprite = goodSprite;
                break;
            case 4:
                countText.text = "Great";
                resultImage.sprite = greatSprite;
                break;
            case 5:
                countText.text = "Perfect!";
                resultImage.sprite = perfectSprite;
                break;
            case 6:
                countText.text = "Miss...";
                resultImage.sprite = missSprite;
                break;
        }

        // Image を表示
        resultImage.enabled = true;

        StartCoroutine(PlayGoalSE());
    }

    private IEnumerator PlayGoalSE()
    {
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }

        if (sfxSource != null && goalSE != null)
        {
            sfxSource.PlayOneShot(goalSE);
            yield return new WaitForSeconds(goalSE.length);
        }

        button.interactable = true;
    }
}
