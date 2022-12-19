using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private float _pause;

    private Transform[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var pause = new WaitForSeconds(_pause);

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_template, _spawnPoints[i].transform.position, Quaternion.identity);
            yield return pause;
        }
    }
}
