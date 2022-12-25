using DG.Tweening;
using UnityEngine;

public class MaceMovement : MonoBehaviour
{
    [SerializeField] private float _pathTime;
    [SerializeField] private float _targetY;

    private void Start()
    {
        transform.DOMoveY(_targetY, _pathTime).SetLoops(-1, LoopType.Yoyo);
    }
}
