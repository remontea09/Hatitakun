using UnityEngine;

public class Rain : MonoBehaviour
{
    [Header("自動消滅時間")]
    [SerializeField] private float lifeTime = 5f;

    private void Start()
    {
        // 時間経過で消える
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerGrowth growth = other.GetComponent<PlayerGrowth>();

        if (growth)
        {
            growth.Grow();   // 成長
            Destroy(gameObject); // プレイヤーに当たったら消える
        }

        if (other.CompareTag("Dead"))
        {
            Destroy(this.gameObject);
        }
    }
}

