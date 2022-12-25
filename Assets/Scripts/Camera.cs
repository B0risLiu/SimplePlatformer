using System.Collections;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Player _target;

    private float _cameraSpead = 1f;
    private float _lastTargetX;
    private Coroutine _workingCoroutine;

    private void Start()
    {
        _lastTargetX = _target.transform.position.x;
        _workingCoroutine = StartCoroutine(MoveCamera());
    }

    private void FixedUpdate()
    {
        if (_lastTargetX != _target.transform.position.x)
        {
            if (_workingCoroutine != null)
                StopCoroutine(MoveCamera());

            _lastTargetX = _target.transform.position.x;
            StartCoroutine(MoveCamera());
        }
    }

    private IEnumerator MoveCamera()
    {
        while (_lastTargetX != transform.position.x)
        {
            float cameraX = Mathf.MoveTowards(transform.position.x, _lastTargetX, _cameraSpead);
            transform.position = new Vector3(cameraX, transform.position.y, transform.position.z);
            yield return null;
        }

        _workingCoroutine = null;
    }
}
