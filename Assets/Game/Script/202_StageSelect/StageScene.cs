using UnityEngine;
using UnityEngine.SceneManagement;


public class StageScene : MonoBehaviour
{
    //í«â¡ÇµÇΩÇ¢ÉVÅ[ÉìñºÇèëÇ¢ÇƒÇ≠ÇæÇ≥Ç¢
    [SerializeField] private string[] scene = { "GameScene", "GameScene", "GameScene", "GameScene", "GameScene",
                                                "GameScene", "GameScene", "GameScene", "GameScene", "GameScene", };



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //void Start()
    //{
        
    //}

    public void PlayStage1()
    {
        SceneManager.LoadScene(scene[0]);
    }

    public void PlayStage2()
    {
        SceneManager.LoadScene(scene[1]);
    }

    public void PlayStage3()
    {
        SceneManager.LoadScene(scene[2]);
    }
    public void PlayStage4()
    {
        SceneManager.LoadScene(scene[3]);
    }
    public void PlayStage5()
    {
        SceneManager.LoadScene(scene[4]);
    }
    public void PlayStage6()
    {
        SceneManager.LoadScene(scene[5]);
    }
    public void PlayStage7()
    {
        SceneManager.LoadScene(scene[6]);
    }
    public void PlayStage8()
    {
        SceneManager.LoadScene(scene[7]);
    }
    public void PlayStage9()
    {
        SceneManager.LoadScene(scene[8]);
    }
    public void PlayStage10()
    {
        SceneManager.LoadScene(scene[9]);
    }


    // Update is called once per frame

}
