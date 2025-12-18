using UnityEngine;

public class BeeEnemy : MonoBehaviour
{
    enum BeeState
    {
        Idle,      // ふわふわ待機
        Chase,     // プレイヤー追跡
        FlyAway    // 命中後に上昇
    }

    [Header("移動設定")]
    public float moveSpeed = 3f;
    public float flyUpSpeed = 5f;

    [Header("追跡距離")]
    public float chaseStartDistance = 6f;   // これ以内で追う
    public float chaseEndDistance = 8f;     // これ以上で諦める

    [Header("ふわふわ待機")]
    public float floatAmplitude = 0.3f;
    public float floatSpeed = 2f;

    private Transform player;
    private PlayerGrowth playerGrowth;
    private BeeState state = BeeState.Idle;

    private Vector3 idleBasePosition;
    private float floatTimer;
    private bool hasAttacked = false;
    private bool isGameClear = false;

    private Goal goal;

    void Start()
    {
        idleBasePosition = transform.position;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            playerGrowth = playerObj.GetComponent<PlayerGrowth>();
        }

        // Goalのイベントに登録
        goal = FindObjectOfType<Goal>();
        if (goal != null)
        {
            goal.onGoal += OnGameClear;
        }
    }

    void OnDestroy()
    {
        // 登録解除
        if (goal != null)
        {
            goal.onGoal -= OnGameClear;
        }
    }


    void Update()
    {
        if (isGameClear)
        {
            // ゴール後は常にふわふわ
            if (state != BeeState.Idle)
            {
                ReturnToIdle();
            }

            Floating();
            return;
        }

        if (player == null || playerGrowth == null) return;

        switch (state)
        {
            case BeeState.Idle:
                UpdateIdle();
                break;

            case BeeState.Chase:
                UpdateChase();
                break;

            case BeeState.FlyAway:
                UpdateFlyAway();
                break;
        }
    }

    // --------------------
    // Idle（ふわふわ）
    // --------------------
    void UpdateIdle()
    {
        Floating();

        if (playerGrowth.currentLevel < PlayerGrowth.GrowthLevel.Level2)
            return;

        float dist = Vector2.Distance(transform.position, player.position);
        if (dist <= chaseStartDistance)
        {
            state = BeeState.Chase;
        }
    }

    // --------------------
    // Chase（追跡）
    // --------------------
    void UpdateChase()
    {
        if (playerGrowth.currentLevel < PlayerGrowth.GrowthLevel.Level2)
        {
            ReturnToIdle();
            return;
        }

        float dist = Vector2.Distance(transform.position, player.position);

        // 一定距離離れたら追跡をやめる
        if (dist >= chaseEndDistance)
        {
            ReturnToIdle();
            return;
        }

        UpdateFacingDirection();

        Vector2 dir = (player.position - transform.position).normalized;
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    // --------------------
    // FlyAway（命中後）
    // --------------------
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

    // --------------------
    // ふわふわ処理
    // --------------------
    void Floating()
    {
        floatTimer += Time.deltaTime * floatSpeed;
        float yOffset = Mathf.Sin(floatTimer) * floatAmplitude;

        transform.position = new Vector3(
            idleBasePosition.x,
            idleBasePosition.y + yOffset,
            idleBasePosition.z
        );
    }

    // --------------------
    // 向き制御
    // --------------------
    void UpdateFacingDirection()
    {
        Vector3 scale = transform.localScale;

        if (player.position.x > transform.position.x)
            scale.x = -Mathf.Abs(scale.x);
        else
            scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;
    }

    // --------------------
    // 当たり判定
    // --------------------
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
    }
    public void OnGameClear()
    {
        isGameClear = true;
        ReturnToIdle();
    }
}
