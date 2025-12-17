using UnityEngine;
using UnityEngine.UI;

public class HelpManager : MonoBehaviour
{

    [SerializeField] private Button helpButton;
    [SerializeField] private Button helpExitButton;

    private void Awake()
    {
        helpButton.onClick.AddListener(() => this.gameObject.SetActive(true));
        helpExitButton.onClick.AddListener(() => this.gameObject.SetActive(false));
        this.gameObject.SetActive(false);
    }
}
