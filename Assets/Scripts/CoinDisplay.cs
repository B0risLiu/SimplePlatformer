using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _coinAmount;

    public void UpdateValue()
    {
        _coinAmount.text = _player.CoinsAmount.ToString();
    }
}
