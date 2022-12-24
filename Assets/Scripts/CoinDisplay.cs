using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _coinAmount;

    public void UpdateValue()
    {
        _coinAmount.text = _player.CoinAmount.ToString();
    }


}
