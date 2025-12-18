using System;
using System.Collections;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    public event Action onGameOver;
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip gameoverSE;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead"))
        {
            StartCoroutine(PlayGoalSE());
        }

    }
    private IEnumerator PlayGoalSE()
    {
        onGameOver?.Invoke();
        if (bgmSource != null)
        {
            bgmSource.Stop();
        }
        if (sfxSource != null && gameoverSE != null)
        {
            sfxSource.PlayOneShot(gameoverSE);
            // SE‚Ì’·‚³‚¾‚¯‘Ò‚Â
            yield return new WaitForSeconds(gameoverSE.length);
        }
    }
    }