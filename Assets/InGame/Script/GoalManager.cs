using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private Button button;

    // 追加：雨生成管理
    [SerializeField] private RainSpawner rainSpawner;

    // 追加：BGM とゴール効果音
    [Header("サウンド")]
    [SerializeField] private AudioSource bgmSource;    // 再生中のBGM
    [SerializeField] private AudioSource sfxSource;    // 効果音用
    [SerializeField] private AudioClip goalSE;         // ゴール時に鳴らす効果音

    private void Awake()
    {
        button.onClick.AddListener(() => SceneManager.LoadScene("TitleScene"));
        button.interactable = false; // 最初は押せないようにしておく
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

        // BGMを止めてゴール音を鳴らす
        StartCoroutine(PlayGoalSE());
    }

    private IEnumerator PlayGoalSE()
    {
        // BGM停止
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }

        // ゴールSE再生
        if (sfxSource != null && goalSE != null)
        {
            sfxSource.PlayOneShot(goalSE);
            // SEの長さだけ待つ
            yield return new WaitForSeconds(goalSE.length);
        }

        // 効果音が鳴り終わったらボタンを押せるようにする
        button.interactable = true;
    }
}
