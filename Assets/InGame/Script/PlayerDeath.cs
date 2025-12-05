using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    public event Action onGameOver;
    [SerializeField] private AudioSource bgmSource;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead"))
        {
            onGameOver?.Invoke();
            if (bgmSource != null)
            {
                bgmSource.Stop();
            }
        }
    }
}