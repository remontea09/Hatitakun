using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] private Button Left;
    [SerializeField] private Button Right;
    [SerializeField] private GameObject LeftButton;
    [SerializeField] private GameObject RightButton;
    [SerializeField] private int StagePanel = 1;//最初に表示するステージのページ
    [SerializeField] private TextMeshProUGUI stageN;//は矢印で増減


    [SerializeField] private GameObject NumberPanel1;//コピーして入れたいステージを増やす

    [SerializeField] private Button Dest;

    //int Num = NumberManager.Number;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (StagePanel == 1)
        {
            LeftButton.SetActive(false);
        }

        Left.onClick.AddListener(StageC);
        Right.onClick.AddListener(StageC);



        Dest.onClick.AddListener(Desty);


    }

    private void StageC()
    {

    }

    private void Desty()
    {
        NumberPanel1.SetActive(false);



    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

//stageの切り替え機能を作る