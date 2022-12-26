using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _coinAmount;

    private void OnEnable()
    {
        _player.CoinsAmountChanged += UpdateDisplay;
    }

    private void OnDisable()
    {
        _player.CoinsAmountChanged -= UpdateDisplay;
    }

    public void UpdateDisplay()
    {
        _coinAmount.text = _player.CoinsAmount.ToString();
    }
}
