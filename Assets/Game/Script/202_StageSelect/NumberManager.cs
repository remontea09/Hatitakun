using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    //ステージは1ステージ10個までの想定

    [SerializeField] private int Number = 1; //現在のステージの面を決める Number - 1　→　1 - 1
    [SerializeField][Range(0,10)] private int stage = 10; //ステージの個数を決める、10まで入力可能 1 - stage → 1-10

    [SerializeField] private TextMeshProUGUI[] StageN = default; // 文字を入れる                
    [SerializeField] private GameObject[] stageButton = default; // ステージボタンの配列            10個
    [SerializeField] private Button[] Button = default;          // ボタンが反応するようになる      設定して
    [SerializeField] private Image[] Button_Image = default;     // ボタンの色などを操作します      ください

    [SerializeField] private StageScene stageScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ステージの番号を書くのに使う
        string[] myBox = new string[10];


        //ステージの番号を書く準備
        for (int i = 0; i < stage; i++)
        {
            myBox[i] = Number + "-" + (i + 1);
        }

        //要らないボタンを非表示
        for (int i = 9; i >= stage; i--)
        {
            //Destroy(stageButton[i]);
            stageButton[i].SetActive(false);
        }

        //ステージの番号を書きます
        for (int i = 0; i < stage; i++)
        {
            StageN[i].text = myBox[i];
        }

        //シーン遷移するための機能
        Button[0].onClick.AddListener(Play1);
        Button[1].onClick.AddListener(Play2);
        Button[2].onClick.AddListener(Play3);
        Button[3].onClick.AddListener(Play4);
        Button[4].onClick.AddListener(Play5);
        Button[5].onClick.AddListener(Play6);
        Button[6].onClick.AddListener(Play7);
        Button[7].onClick.AddListener(Play8);
        Button[8].onClick.AddListener(Play9);
        Button[9].onClick.AddListener(Play10);

        CheckClearStage();

    }

    private void CheckClearStage()
    {
        for(int i = 1; i < ClearStageService.totalStages; i++)
        {
            if (ClearStageService.clearStageFlags[i - 1])
            {
                Button[i].enabled = true;
                Button_Image[i].color = new Color(1f, 1f, 1f, 1f);  //クリアしたら非透明になる
            }
            else
            {
                Button[i].enabled = false;
            }
        }
    }

    //シーン遷移するための機能
    #region

    private void Play1() {
        stageScene.PlayStage1();
    }
    private void Play2()
    {
        stageScene.PlayStage2();
    }
    private void Play3()
    {
        stageScene.PlayStage3();
    }
    private void Play4()
    {
        stageScene.PlayStage4();
    }
    private void Play5()
    {
        stageScene.PlayStage5();
    }
    private void Play6()
    {
        stageScene.PlayStage6();
    }
    private void Play7()
    {
        stageScene.PlayStage7();
    }
    private void Play8()
    {
        stageScene.PlayStage8();
    }
    private void Play9()
    {
        stageScene.PlayStage9();
    }
    private void Play10()
    {
        stageScene.PlayStage10();
    }

    #endregion

}
