using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(AudioSource))]

public class ClickyButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private AudioClip _buttonDownSound;
    [SerializeField] private AudioClip _buttonUpSound;
    [SerializeField] private Sprite _highlightedSprite;

    [SerializeField] private UnityEvent _clicked;

    private Sprite _defaultSprite;
    private Image _image;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _image = GetComponent<Image>();
        _defaultSprite = _image.sprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(_buttonDownSound);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.sprite = _highlightedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.sprite = _defaultSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(_buttonUpSound);
        _clicked.Invoke();
    }
}
