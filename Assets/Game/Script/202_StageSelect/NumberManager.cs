using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NumberManager : MonoBehaviour
{
                                             //ステージは1ステージ10個の想定
    [SerializeField] private int stage = 10; //ステージの個数を決める、10まで入力可能
    [SerializeField] private static int Number = 1; //現在のステージを決める Number - 1
    
    [SerializeField]private TextMeshProUGUI[] StageN = default; // 文字を入れるやつ
    [SerializeField]private GameObject[] stageButton = default; // ステージ選択ボタンの配列


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string[] myBox = new string[10];



        for (int i = 0; i < stage; i++)
        {
            myBox[i] = Number + "-" + (i + 1);
        }

        for (int i = 0; i < stage; i++)
        {
            StageN[i].text = myBox[i];
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
