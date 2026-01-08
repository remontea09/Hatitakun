using UnityEngine;

public class BeeEnemy : MonoBehaviour
{

    public AudioClip se;
    enum BeeState { Idle, Chase, FlyAway }

    [Header("移動設定")]
    public float moveSpeed = 3f;
    public float flyUpSpeed = 5f;

    [Header("追跡距離")]
    public float chaseStartDistance = 6f;
    public float chaseEndDistance = 8f;

    [Header("ふわふわ待機")]
    public float floatAmplitude = 0.3f;
    public float floatSpeed = 2f;

    [Header("ゴール参照")]
    [SerializeField] private Goal goal; // Inspectorで割り当て

    private Transform player;
    private PlayerGrowth playerGrowth;
    private BeeState state = BeeState.Idle;

    private Vector3 idleBasePosition;
    private float floatTimer;
    private bool hasAttacked = false;
    private bool isGameClear = false;

    void Start()
    {
        idleBasePosition = transform.position;

        // プレイヤー取得
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            playerGrowth = playerObj.GetComponent<PlayerGrowth>();
        }

        // Goalイベント登録
        if (goal != null)
            goal.onGoal += OnGameClear;
    }

    void OnDestroy()
    {
        if (goal != null)
            goal.onGoal -= OnGameClear;
    }

    void Update()
    {
        if (player == null || playerGrowth == null) return;

        if (isGameClear)
        {
            if (state != BeeState.Idle) ReturnToIdle();
            Floating();
            return;
        }

        switch (state)
        {
            case BeeState.Idle: UpdateIdle(); break;
            case BeeState.Chase: UpdateChase(); break;
            case BeeState.FlyAway: UpdateFlyAway(); break;
        }
    }

    void UpdateIdle()
    {
        Floating();

        if (playerGrowth.currentLevel < PlayerGrowth.GrowthLevel.Level2) return;

        float dist = Vector2.Distance(transform.position, player.position);
        if (dist <= chaseStartDistance)
            state = BeeState.Chase;
    }

    void UpdateChase()
    {
        if (playerGrowth.currentLevel < PlayerGrowth.GrowthLevel.Level2)
        {
            ReturnToIdle();
            return;
        }

        float dist = Vector2.Distance(transform.position, player.position);
        if (dist >= chaseEndDistance)
        {
            ReturnToIdle();
            return;
        }

        UpdateFacingDirection();
        Vector2 dir = (player.position - transform.position).normalized;
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    void UpdateFlyAway()
    {
        transform.Translate(Vector2.up * flyUpSpeed * Time.deltaTime);
    }

    void ReturnToIdle()
    {
        state = BeeState.Idle;
        idleBasePosition = transform.position;
        floatTimer = 0f;
    }

    void Floating()
    {
        floatTimer += Time.deltaTime * floatSpeed;
        float yOffset = Mathf.Sin(floatTimer) * floatAmplitude;
        transform.position = new Vector3(idleBasePosition.x, idleBasePosition.y + yOffset, idleBasePosition.z);
    }

    void UpdateFacingDirection()
    {
        Vector3 scale = transform.localScale;
        scale.x = (player.position.x > transform.position.x) ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasAttacked) return;

        if (collision.CompareTag("Player"))
        {
            PlayerGrowth pg = collision.GetComponent<PlayerGrowth>();
            if (pg != null && pg.currentLevel > PlayerGrowth.GrowthLevel.Level1)
            {
                pg.currentLevel--;
                pg.SendMessage("UpdateSprout", SendMessageOptions.DontRequireReceiver);
                pg.BlinkPlayer();

                hasAttacked = true;
                state = BeeState.FlyAway;

                Destroy(gameObject, 1.5f);
            }
        }
        AudioSource.PlayClipAtPoint(se, transform.position);

    }

    public void OnGameClear()
    {
        isGameClear = true;
        ReturnToIdle();
    }
}
