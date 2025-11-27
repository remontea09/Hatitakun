using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    [SerializeField] private string _loadScene; //シーン名を記述

    public void SceneChange()//On.Clickにこのメソッドを選択
    {
        SceneManager.LoadScene(_loadScene);
    }

}

//リンク
//https://qiita.com/mizuki170817/items/7fabff96c35aac7fb555