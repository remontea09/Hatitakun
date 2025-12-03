using UnityEngine;

public class Exit_Button : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Unityエディターでの動作
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 実際のゲーム終了処理
        Application.Quit();
#endif
    }
}

//リンク
//https://cbagames.jp/2024/01/26/unity-exit-game-button-tutorial/