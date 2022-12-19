using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallSensor : MonoBehaviour
{
    [SerializeField] private UnityEvent _sensorOn;
    [SerializeField] private UnityEvent _sensorOff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground))
            _sensorOn.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground))
            _sensorOff.Invoke();
    }
}
