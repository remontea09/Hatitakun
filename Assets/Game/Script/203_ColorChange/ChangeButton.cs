using UnityEngine;
using UnityEngine.UI;

public class ChangeButton : MonoBehaviour
{
    [SerializeField] private Button C_Button;
    [SerializeField] private GameObject ChangePanel;
    [SerializeField] private GameObject BlockPanel;
    [SerializeField] private GameObject ChangeText;


    [SerializeField] private ChangeText changeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        C_Button.onClick.AddListener(C);


    }

    private void C()
    {
        ChangePanel.SetActive(true);
        BlockPanel.SetActive(true);
        changeText.Ctxet();
    }


}
