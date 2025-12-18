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

    [SerializeField] private SpriteRenderer nomalRight;
    [SerializeField] private SpriteRenderer nomalLeft;
    [SerializeField] private SpriteRenderer angelRight;
    [SerializeField] private SpriteRenderer angelLeft;
    [SerializeField] private SpriteRenderer devilRight;
    [SerializeField] private SpriteRenderer devilLeft;
    [SerializeField] private SpriteRenderer catRight;
    [SerializeField] private SpriteRenderer catLeft;
    [SerializeField] private SpriteRenderer heroRight;
    [SerializeField] private SpriteRenderer heroLeft;

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

    public void SetSkin(SkinType skin)
    {
        skinType = skin;
    }
}