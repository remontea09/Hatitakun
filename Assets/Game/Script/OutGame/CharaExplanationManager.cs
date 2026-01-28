using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaExplanationManager : MonoBehaviour
{

    //à–¾‚Æƒ{ƒ^ƒ“‚ğ‘Î‰‚³‚¹“¯‚¶‡”Ô‚Å“ü‚ê‚é
    [SerializeField] private List<Sprite> explanationList;
    [SerializeField] private Image explanationImage;
    [SerializeField] private List<Button> skinSelectButtonList;

    private void Start()
    {
        for(int i = 0; i < skinSelectButtonList.Count; i++)
        {
            SetExplanationImage(explanationList[i], skinSelectButtonList[i]);
        }
    }

    private void SetExplanationImage(Sprite sprite, Button button)
    {
        button.onClick.AddListener(() => explanationImage.sprite = sprite);
    }

}
