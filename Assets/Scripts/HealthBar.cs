using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _fill;
    [SerializeField] private TextMeshProUGUI _healthAmount;
    [SerializeField] private float _healthChangingTime;

    private void Start()
    {
        _healthAmount.text = _player.MaxHealth.ToString();
    }

    public void UpdateValue()
    {
        _healthAmount.text = _player.Health.ToString();
        _fill.DOFillAmount((float)_player.Health / _player.MaxHealth, _healthChangingTime);
    }
}
