using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoExhibition : MonoBehaviour
{ 
    // タイトルシーンの名前をインスペクターで設定可能
    public string stageSelectSceneName = "FrowerExhibition";

    // この関数をボタンのOnClick()に設定
    public void GoToExhibition()
    {
        SceneManager.LoadScene(stageSelectSceneName);
    }

}
