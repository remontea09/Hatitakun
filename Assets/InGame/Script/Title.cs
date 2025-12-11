using UnityEngine;
using UnityEngine.SceneManagement; // SceneManagerを使うために必要

public class Title : MonoBehaviour
{
    // タイトルシーンの名前をインスペクターで設定可能
    public string titleSceneName = "TitleScene";

    // この関数をボタンのOnClick()に設定
    public void GoToTitle()
    {
        SceneManager.LoadScene(titleSceneName);
    }
}
