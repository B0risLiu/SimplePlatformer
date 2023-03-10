using DG.Tweening;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    [SerializeField] private float _pathTime;
    [SerializeField] private float _targetX;

    private void Start()
    {
        transform.DOMoveX(_targetX, _pathTime).SetLoops(-1, LoopType.Yoyo);
    }
}
