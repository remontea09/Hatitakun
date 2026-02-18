using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Talks
{

    public event Action EndRead;

    public IEnumerator Story1(TextMeshProUGUI text, GameObject messageWindow)
    {
        messageWindow.gameObject.SetActive(true);
        text.text = "僕ははち田くん。よろしくね！";
        yield return new WaitForSeconds(3);
        messageWindow.gameObject.SetActive(false);
        EndRead?.Invoke();
    }

    public IEnumerator Story2(TextMeshProUGUI text, GameObject messageWindow)
    {
        messageWindow.gameObject.SetActive(true);
        text.text = "早く冒険したいなあ";
        yield return new WaitForSeconds(3);
        messageWindow.gameObject.SetActive(false);
        EndRead?.Invoke();
    }

    public IEnumerator Story3(TextMeshProUGUI text, GameObject messageWindow)
    {
        messageWindow.gameObject.SetActive(true);
        text.text = "僕の花、どこまで育つかなあ？";
        yield return new WaitForSeconds(3);
        messageWindow.gameObject.SetActive(false);
        EndRead?.Invoke();
    }

    public IEnumerator Story4(TextMeshProUGUI text, GameObject messageWindow)
    {
        messageWindow.gameObject.SetActive(true);
        text.text = "こけて割れないか心配だよ……";
        yield return new WaitForSeconds(3);
        messageWindow.gameObject.SetActive(false);
        EndRead?.Invoke();
    }

    public IEnumerator Story5(TextMeshProUGUI text, GameObject messageWindow)
    {
        messageWindow.gameObject.SetActive(true);
        text.text = "いつか綺麗な花を咲かせるんだ！";
        yield return new WaitForSeconds(3);
        messageWindow.gameObject.SetActive(false);
        EndRead?.Invoke();
    }

}
