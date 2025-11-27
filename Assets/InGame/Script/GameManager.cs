using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private HatitaController hatitakun;
    [SerializeField] private Goal goal;
    [SerializeField] private GameObject goalPanel;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        goalPanel.SetActive(false);
        goal.onGoal += OnGoal;
    }


    private void OnGoal()
    {
        goalPanel.SetActive(true);
        hatitakun.ChangeIsMove(false);
    }

}
