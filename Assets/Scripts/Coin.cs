using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Coin : MonoBehaviour
{
    [SerializeField] private float _pauseBeforeDeleting;

    private AudioSource _audioSource;
    private bool _isCollected;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player) && _isCollected == false)
        {
            _isCollected = true;
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
