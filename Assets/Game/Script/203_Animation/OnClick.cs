using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject panel;

    public void OnPointerClick(PointerEventData eventData)
    {
        // クリックされた時に行いたい処理
        //panel.SetActive(true);
        //Debug.Log("押されたよ");

        if (panel == true)
        {
            panel.SetActive(false);
            Debug.Log("消す");
        }
        //else if (panel == false)
        //{
        //    panel.SetActive(true);
        //    Debug.Log("押されたよ");
        //}


    }
}