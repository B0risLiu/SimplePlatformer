using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _fill;
    [SerializeField] private TextMeshProUGUI _healthAmount;
    [SerializeField] private float _healthChangingTime;

    private void OnEnable()
    {
        _player.HealthChanged += UpdateHealthBar;
        _healthAmount.text = _player.MaxHealth.ToString();
    }

    private void OnDisable()
    {
        _player.HealthChanged -= UpdateHealthBar;
    }
    
    public void UpdateHealthBar()
    {
        _healthAmount.text = _player.Health.ToString();
        _fill.DOFillAmount((float)_player.Health / _player.MaxHealth, _healthChangingTime);
    }
}
