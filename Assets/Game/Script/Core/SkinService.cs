using UnityEngine;


public enum SkinType
{
    normal,
    angel,
    devil,
    cat,
    hero,
    rain
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
    [SerializeField] private Sprite rainRight;
    [SerializeField] private Sprite rainLeft;

    public static SkinService Instance { get; private set; }

    [SerializeField] private bool dontDestroyOnLoad = true;

    public SkinType skinType { get; private set; }

    //ステータス
    private bool heroTakeDamage = false;

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

    public void GetSkinSprites(out Sprite right, out Sprite left)
    {
        switch (skinType)
        {
            case SkinType.normal: right = nomalRight; left = nomalLeft; break;
            case SkinType.angel: right = angelRight; left = angelLeft; break;
            case SkinType.devil: right = devilRight; left = devilLeft; break;
            case SkinType.cat: right = catRight; left = catLeft; break;
            case SkinType.hero: right = heroRight; left = heroLeft; break;
            case SkinType.rain: right = rainRight; left = rainLeft; break;
            default: right = nomalRight; left = nomalLeft; break;
        }
    }

    public void GetSkinSprites(out Sprite sprite)
    {
        switch (skinType)
        {
            case SkinType.normal: sprite = nomalRight; break;
            case SkinType.angel: sprite = angelRight; break;
            case SkinType.devil: sprite = devilRight; break;
            case SkinType.cat: sprite = catRight; break;
            case SkinType.hero: sprite = heroRight; break;
            case SkinType.rain: sprite = rainRight; break;
            default: sprite = nomalRight; break;
        }
    }

    public bool CanHeroTakeDamage()
    {
        if(skinType == SkinType.hero)
        {
            return heroTakeDamage;
        }
        else
        {
            return true;
        }
    }

    public void ChangeHeroTakeDamage(bool b)
    {
        heroTakeDamage = b;
    }

    public SkinType GetSkinType()
    {
        return skinType; 
    }
}