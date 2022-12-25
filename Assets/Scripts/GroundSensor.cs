using UnityEngine;
using UnityEngine.Events;

public class GroundSensor : MonoBehaviour
{
    [SerializeField] private UnityEvent _sensorOn;
    [SerializeField] private UnityEvent _sensorOff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground)
            || collision.TryGetComponent<Platform>(out Platform platform))
                _sensorOn.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground)
            || collision.TryGetComponent<Platform>(out Platform platform))
            _sensorOff.Invoke();
    }
}
