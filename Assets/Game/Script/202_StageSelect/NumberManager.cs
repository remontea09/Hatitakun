using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    //シーンを切り替えるには手動で書いてください
    //ステージは1ステージ10個の想定

    [SerializeField] private int stage = 10; //ステージの個数を決める、10まで入力可能
    [SerializeField] private static int Number = 1; //現在のステージを決める Number - 1

    [SerializeField] private TextMeshProUGUI[] StageN = default; // 文字を入れるやつ
    [SerializeField] private GameObject[] stageButton = default; // ステージ選択ボタンの配列
    [SerializeField] private Button[] Button = default; // ステージ選択ボタンの配列

    [SerializeField] private StageScene stageScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string[] myBox = new string[10];



        for (int i = 0; i < stage; i++)
        {
            myBox[i] = Number + "-" + (i + 1);
        }

        for (int i = 9; i >= stage; i--)
        {
            Destroy(stageButton[i]);
        }

        for (int i = 0; i < stage; i++)
        {
            StageN[i].text = myBox[i];
        }

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

    }

    //シーン遷移するため機能
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
