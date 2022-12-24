using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _fill;
    [SerializeField] private TextMeshProUGUI _healthAmount;
    [SerializeField] private float _healthChangingTime;

    public void UpdateValue()
    {
        _healthAmount.text = _player.Health.ToString();
        _fill.DOFillAmount((float)_player.Health / _player.MaxHealth, _healthChangingTime);
    }

    private void Start()
    {
        _healthAmount.text = _player.MaxHealth.ToString();
    }
}
