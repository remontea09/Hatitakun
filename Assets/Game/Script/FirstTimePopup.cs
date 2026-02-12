using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FirstTimePopup : MonoBehaviour
{
    public GameObject popupPanel;
    public RectTransform popupTransform;

    void Start()
    {
        //PlayerPrefs.DeleteKey(SceneManager.GetActiveScene().name + "_Visited");

        string key = SceneManager.GetActiveScene().name + "_Visited";
        if (!PlayerPrefs.HasKey(key))
        {
            StartCoroutine(PopupSmooth());
            PlayerPrefs.SetInt(key, 1);
            PlayerPrefs.Save();
        }
        else
        {
            popupTransform.localScale = Vector3.zero;
        }
    }

    IEnumerator PopupSmooth()
    {
        popupTransform.localScale = Vector3.zero;

        float duration = 0.3f; // アニメーション時間
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            // イージング（滑らかに0→1）
            float scale = Mathf.SmoothStep(0, 1, t);

            popupTransform.localScale = new Vector3(scale, scale, 1);
            yield return null;
        }

        popupTransform.localScale = Vector3.one;
    }
    public void ClosePopup() { popupPanel.SetActive(false); }
}