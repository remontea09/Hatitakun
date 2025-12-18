using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    //[SerializeField] private int stage = 10; //ステージの個数を決める、10まで入力可能
    [SerializeField] private int Number = 1; //現在のステージを決める Number - 1
    [SerializeField] private TextMeshProUGUI stageN1;
    [SerializeField] private TextMeshProUGUI stageN2;
    [SerializeField] private TextMeshProUGUI stageN3;
    [SerializeField] private TextMeshProUGUI stageN4;
    [SerializeField] private TextMeshProUGUI stageN5;
    [SerializeField] private TextMeshProUGUI stageN6;
    [SerializeField] private TextMeshProUGUI stageN7;
    [SerializeField] private TextMeshProUGUI stageN8;
    [SerializeField] private TextMeshProUGUI stageN9;
    [SerializeField] private TextMeshProUGUI stageN10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
            stageN1.text = Number +  "-" + 1;
            stageN2.text = Number +  "-" + 2;
            stageN3.text = Number +  "-" + 3;
            stageN4.text = Number +  "-" + 4;
            stageN5.text = Number +  "-" + 5;
            stageN6.text = Number +  "-" + 6;
            stageN7.text = Number +  "-" + 7;
            stageN8.text = Number +  "-" + 8;
            stageN9.text = Number +  "-" + 9;
            stageN10.text = Number +  "-" + 10;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//stageタグの追加
//ステージ数変更