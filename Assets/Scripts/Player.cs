using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

[RequireComponent(typeof(SpriteRenderer))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _invincibilityTime;
    [SerializeField] private float _blinkSpeed;

    private SpriteRenderer _spriteRenderer;
    private bool _isInvincible;

    public int CoinAmount { get; private set; }

    public void AddCoin()
    {
        CoinAmount++;
    }

    public void TakeDamage()
    {
        if (_isInvincible == false)
        {
            _isInvincible = true;
            StartCoroutine(Blink());
        }
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private IEnumerator Blink()
    {
        var targetColor = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0f);
        int loopsAmount = Convert.ToInt32(_invincibilityTime / _blinkSpeed);
        loopsAmount = loopsAmount % 2 == 0 ? ++loopsAmount : loopsAmount;
        Tween tween = _spriteRenderer.DOColor(targetColor, _blinkSpeed).From().SetLoops(loopsAmount, LoopType.Yoyo);
        yield return tween.WaitForCompletion();
        _isInvincible = false;
    }
}
