using UnityEngine;
using UnityEngine.SceneManagement; // SceneManagerを使うために必要

public class Stage : MonoBehaviour
{
    // タイトルシーンの名前をインスペクターで設定可能
    public string stageSelectSceneName = "StageSelectScene";

    // この関数をボタンのOnClick()に設定
    public void GoToTitle()
    {
        SceneManager.LoadScene(stageSelectSceneName);
    }
}
