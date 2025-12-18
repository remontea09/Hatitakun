using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float shakeDuration = 0.5f;     // —h‚ê‚éŠÔ
    public float shakeStrength = 0.05f;    // —h‚ê‚Ì‹­‚³
    public float fallDelay = 0.5f;         // —h‚êI‚í‚Á‚Ä‚©‚ç—‚¿‚é‚Ü‚Å‚Ì’x‰„
    public float destroyDelay = 3f;        // —‰ºŒã‚ÉÁ‚¦‚é‚Ü‚Å‚ÌŠÔ

    private Rigidbody2D rb;
    private bool isTriggered = false;
    private Vector3 originalPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        originalPos = transform.localPosition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isTriggered && collision.collider.CompareTag("Player"))
        {
            isTriggered = true;
            StartCoroutine(ShakeAndFall());
        }
    }

    private System.Collections.IEnumerator ShakeAndFall()
    {
        // ---- —h‚êƒAƒjƒ ----
        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-shakeStrength, shakeStrength);
            float y = Random.Range(-shakeStrength, shakeStrength);

            transform.localPosition = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // —h‚êI—¹ ¨ Œ³‚ÌˆÊ’u‚É–ß‚·
        transform.localPosition = originalPos;

        // ­‚µ‘Ò‚Á‚Ä‚©‚ç—‰º
        yield return new WaitForSeconds(fallDelay);

        // ---- —‰ºŠJn ----
        rb.bodyType = RigidbodyType2D.Dynamic;

        Destroy(gameObject, destroyDelay);
    }
}
