using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeButtonManager : MonoBehaviour
{

    [SerializeField] private Button skinSceneButton;
    [SerializeField] private Button gameSceneButton;
    [SerializeField] private Button titleSceneButton;

    private void Awake()
    {
        skinSceneButton.onClick.AddListener(() => SceneManager.LoadScene("CharacterChange"));
        gameSceneButton.onClick.AddListener(() => SceneManager.LoadScene("StageSelectScene"));
        titleSceneButton.onClick.AddListener(() => SceneManager.LoadScene("TitleScene"));
    }

}
