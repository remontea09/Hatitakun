using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;

    public event Action onGoal;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onGoal?.Invoke();
        }
    }
}
