using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class MedicineKit : MonoBehaviour
{
    [SerializeField] private int _healAmount;
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
            player.Heal(_healAmount);
            StartCoroutine(DeleteKit());
        }
    }

    private IEnumerator DeleteKit()
    {
        var pause = new WaitForSeconds(_pauseBeforeDeleting);
        _audioSource.Play();
        yield return pause;
        Destroy(gameObject);
    }
}
