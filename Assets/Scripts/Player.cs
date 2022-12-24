using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _invincibilityTime;
    [SerializeField] private float _blinkSpeed;
    [SerializeField] private int _maxHealth;
    [SerializeField] private UnityEvent _HealthChanged;
    [SerializeField] private UnityEvent _coinAmountChanged;

    private SpriteRenderer _spriteRenderer;
    private bool _isInvincible;

    public int CoinAmount { get; private set; }
    public int Health { get; private set; }
    public int MaxHealth => _maxHealth;

    public void AddCoin()
    {
        CoinAmount++;
        _coinAmountChanged.Invoke();
    }

    public void TakeDamage(int value)
    {
        if (_isInvincible == false)
        {
            Health -= value;
            Health = Health < 0 ? 0 : Health;
            _HealthChanged.Invoke();

            if (Health > 0)
            {
                _isInvincible = true;
                StartCoroutine(Blink());
            }
            else
                PlayerDie();
        }
    }

    public void Heal(int value)
    {
        Health += value;
        Health = Health > _maxHealth ? _maxHealth : Health;
        _HealthChanged.Invoke();
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Health = _maxHealth;
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

    private void PlayerDie()
    {

    }
}
