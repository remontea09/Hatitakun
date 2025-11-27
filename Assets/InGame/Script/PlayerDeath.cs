using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead"))
        {
            GameManager.Instance.GameOver();
        }
    }
}