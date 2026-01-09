using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] private Button Left;
    [SerializeField] private Button Right;
    [SerializeField] private GameObject LeftButton;
    [SerializeField] private GameObject RightButton;

    [SerializeField] private int StagePanel;//最初に表示するステージのページ・1からNまで入力
    [SerializeField] private static int SPF = 1;//最初のステージのページ

    [SerializeField] private TextMeshProUGUI stageN;//矢印で増減する文字

    [SerializeField] private GameObject[] NumberPanel;//入れたいステージを増やす

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StagePanel = 2;
        //矢印を消す
        if (StagePanel == SPF)
        {
            LeftButton.SetActive(false);
        }
        else if(StagePanel == NumberPanel.Length)
        {
            RightButton.SetActive(false);
        }

        //現在のステージ・増えたら変更
        stageN.text = StagePanel + "/" + NumberPanel.Length;
        //最初に表示するステージのページ
        NumberPanel[StagePanel-1].SetActive(true);

        Left.onClick.AddListener(StageL);
        Right.onClick.AddListener(StageR);

    }

    private void StageL()
    {
        StagePanel--;
        //
        if (StagePanel == SPF)
        {
            LeftButton.SetActive(false);

        }

        RightButton.SetActive(true);


        //現在のステージ
        stageN.text = StagePanel + "/" + NumberPanel.Length;

        NumberPanel[StagePanel-1].SetActive(true);  //現在地表示
        NumberPanel[StagePanel].SetActive(false);   //前の消す
    }
    private void StageR()
    {
        StagePanel++;
        //
        if (StagePanel == NumberPanel.Length)
        {
            RightButton.SetActive(false);
            
        }

        LeftButton.SetActive(true);

        //現在のステージ
        stageN.text = StagePanel + "/" + NumberPanel.Length;

        NumberPanel[StagePanel - 1].SetActive(true);    //現在地表示
        NumberPanel[StagePanel - 2].SetActive(false);   //前の消す

    }

}

//stageの切り替え機能を作る