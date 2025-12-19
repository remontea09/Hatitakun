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


    [SerializeField] private GameObject NumberPanel1;//コピーして入れたいステージを増やす

    [SerializeField] private Button Dest;//消えるか確認用：終わったら消す

    //int Num = NumberManager.Number;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (StagePanel == 1)
        {
            LeftButton.SetActive(false);
        }

        Left.onClick.AddListener(StageL);
        Right.onClick.AddListener(StageR);



        Dest.onClick.AddListener(Desty);//消えるか確認用：終わったら消す


    }

    private void StageL()
    {

    }
    private void StageR()
    {

    }

    private void Desty()//消えるか確認用：終わったら消す
    {
        NumberPanel1.SetActive(false);


    }


}

//stageの切り替え機能を作る