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
    [SerializeField] private TextMeshProUGUI stageN;//は矢印で増減する 文字


    [SerializeField] private GameObject[] NumberPanel;//入れたいステージを増やす


    [SerializeField] private Button Dest;//消えるか確認用：終わったら消す
    [SerializeField] private Button Miru1;//消えるか確認用：終わったら消す
    [SerializeField] private Button Miru2;//消えるか確認用：終わったら消す


    //int Num = NumberManager.Number;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //矢印を消す
        if (StagePanel == 1)
        {
            LeftButton.SetActive(false);
        }

        Left.onClick.AddListener(StageL);
        Right.onClick.AddListener(StageR);


        Dest.onClick.AddListener(Desty);//消えるか確認用：終わったら消す

        Miru1.onClick.AddListener(Mi1);//消えるか確認用：終わったら消す
        Miru2.onClick.AddListener(Mi2);//消えるか確認用：終わったら消す

    }

    private void StageL()
    {

    }
    private void StageR()
    {

    }

    private void Desty()//消えるか確認用：終わったら消す
    {
        for (int i = 0; i < NumberPanel.Length; i++)
        {
            NumberPanel[i].SetActive(false);
        }


    }

    private void Mi1()
    {
        NumberPanel[0].SetActive(true);
    }

    private void Mi2()
    {
        NumberPanel[1].SetActive(true);
    }


}

//stageの切り替え機能を作る