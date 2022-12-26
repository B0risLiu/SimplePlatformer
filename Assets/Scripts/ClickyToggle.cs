using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(AudioSource))]

public class ClickyToggle : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private float PauseBetweenClicks;
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private Sprite _enabledSprite;
    [SerializeField] private Sprite _disabledSprite;

    [SerializeField] private UnityEvent _switchOn;
    [SerializeField] private UnityEvent _switchOff;

    private Image _image;
    private AudioSource _audioSource;
    private Coroutine _workingCoroutine;
    private bool _isOn = true;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _image = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_workingCoroutine == null)
            _workingCoroutine = StartCoroutine(Switch());
    }

    private IEnumerator Switch()
    {
        var pause = new WaitForSeconds(PauseBetweenClicks);
        _audioSource.PlayOneShot(_clickSound);
        _isOn = _isOn == true ? false : true;
        _image.sprite = _isOn == true ? _enabledSprite : _disabledSprite;
        yield return pause;
        _workingCoroutine = null;

        if (_isOn)
            _switchOn.Invoke();
        else
            _switchOff.Invoke();
    }
}
