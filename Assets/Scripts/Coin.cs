using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Coin : MonoBehaviour
{
    [SerializeField] private float _pauseBeforeDeleting;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.AddCoin();
            StartCoroutine(DeleteCoin());
        }
    }

    private IEnumerator DeleteCoin()
    {
        var pause = new WaitForSeconds(_pauseBeforeDeleting);
        _audioSource.Play();
        yield return pause;
        Destroy(gameObject);
    }
}
