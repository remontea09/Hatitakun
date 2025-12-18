using UnityEngine;


public enum SkinType
{
    normal,
    angel,
    devil,
    cat,
    helo
}


public class SkinService : MonoBehaviour
{
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