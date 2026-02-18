using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HatitaTalkManager : MonoBehaviour
{

    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject messageWindow;
    [SerializeField] private Image hatitaImage;

    private Talks talks;

    private bool talking = false;

    private void Awake()
    {
        button.onClick.AddListener(() => StartTalk());
        messageWindow.gameObject.SetActive(false);
        talks = new Talks();
        talks.EndRead += SetFalseTalking;
        Sprite sprite = null;
        SkinService.Instance.GetSkinSprites(out sprite);
        hatitaImage.sprite = sprite;

    }

    private void StartTalk()
    {
        if (!talking)
        {
            int random = UnityEngine.Random.Range(1, 6);
            SearchTalks(random);
        }
    }

    private void SearchTalks(int random)
    {
        switch (random)
        {

            case 1:
                StartCoroutine(talks.Story1(text,messageWindow));
                talking = true;
                break;
            case 2:
                StartCoroutine(talks.Story2(text, messageWindow));
                talking = true;
                break;
            case 3:
                StartCoroutine(talks.Story3(text, messageWindow));
                talking = true;
                break;
            case 4:
                StartCoroutine(talks.Story4(text, messageWindow));
                talking = true;
                break;
            case 5:
                StartCoroutine(talks.Story5(text, messageWindow));
                talking = true;
                break;

        }
    }

    private void SetFalseTalking()
    {
        talking = false;
    }
}
