using System.Collections;
using UnityEngine;

public class Titles : MonoBehaviour
{
    [SerializeField] private float _speadMultiplicator;
    [SerializeField] private float _targetY;

    private Vector3 _startPosition;
    private Coroutine _workingCoroutine;

    private void Start()
    {
        _startPosition = transform.position;
    }

    public void StartTitles()
    {
        _workingCoroutine = StartCoroutine(TitlesRun());
    }

    public void StopTitles()
    {
        if (_workingCoroutine != null)
        {
            StopCoroutine(_workingCoroutine);
        }

        transform.position = _startPosition;
    }

    private IEnumerator TitlesRun()
    {
        while (transform.position.y <= _targetY)
        {
            float curentY = Mathf.MoveTowards(transform.position.y, _targetY, _speadMultiplicator * Time.deltaTime);
            transform.position = new Vector3(_startPosition.x, curentY, _startPosition.z);
            yield return null;
        }
        _workingCoroutine = null;
    }
}
