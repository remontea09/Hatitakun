using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;//スクリプトでUI(テキストなど)扱うときはこれ必須！！

public class ChangeText : MonoBehaviour
{
    public GameObject Cgo_Text;//テキストオブジェクトを入れる変数aをGameObject型で宣言　インスペクター上でTextオブジェクトをアタッチする
    private TextMeshProUGUI Ct_text;//Text型の変数bを宣言

    //スタート関数
    //void Start()
    //{
    //    Ct_text = Cgo_Text.GetComponent<TextMeshProUGUI>();//bにテキストオブジェクトのTextコンポーネントを入れる
    //    Ct_text.text = "1-1";//bに入っているテキストコンポーネントのテキスト変更        
    //}

    public void Ctxet()
    {
        Ct_text = Cgo_Text.GetComponent<TextMeshProUGUI>();//bにテキストオブジェクトのTextコンポーネントを入れる
        Ct_text.text = "1-1";//bに入っているテキストコンポーネントのテキスト変更
    }

}
