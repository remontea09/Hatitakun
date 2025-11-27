using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    public event Action onGameOver;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead"))
        {
            onGameOver?.Invoke();
        }
    }
}