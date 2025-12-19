using UnityEngine;


public enum SkinType
{
    normal,
    angel,
    devil,
    cat,
    hero
}


public class SkinService : MonoBehaviour
{

    [SerializeField] private Sprite nomalRight;
    [SerializeField] private Sprite nomalLeft;
    [SerializeField] private Sprite angelRight;
    [SerializeField] private Sprite angelLeft;
    [SerializeField] private Sprite devilRight;
    [SerializeField] private Sprite devilLeft;
    [SerializeField] private Sprite catRight;
    [SerializeField] private Sprite catLeft;
    [SerializeField] private Sprite heroRight;
    [SerializeField] private Sprite heroLeft;

    public static SkinService Instance { get; private set; }

    [SerializeField] private bool dontDestroyOnLoad = true;

    public SkinType skinType { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if (dontDestroyOnLoad)
            DontDestroyOnLoad(gameObject);
    }

    public void SetSkinType(SkinType skin)
    {
        skinType = skin;
    }

    public void SetSkin(Sprite rightsp, Sprite leftsp)
    {
        switch (skinType)
        {
            case SkinType.normal:
                rightsp = nomalRight;
                leftsp = nomalLeft;
                break;
            case SkinType.angel:
                rightsp = angelRight;
                leftsp = angelLeft;
                break;
            case SkinType.devil:
                rightsp = devilRight;
                leftsp = devilLeft;
                break;
            case SkinType.cat:
                rightsp = devilRight;
                leftsp = devilLeft;
                break;
            case SkinType.hero:
                rightsp = heroRight;
                leftsp = heroLeft;
                break;
            default:
                rightsp = nomalRight;
                leftsp = nomalLeft;
                break;
        }
    }
}