using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _spead;
    [SerializeField] private float _jumpForce;

    private const string Jump = "Jump";
    private const string SpeadX = "SpeadX";
    private const string SpeadY = "SpeadY";
    private const string IsGrounded = "IsGrounded";

    private Rigidbody2D _rb2d;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _isGroundSansorOn;
    private bool _isRightWallSensorOn;
    private bool _isLeftWallSensorOn;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (inputX > 0)
            _spriteRenderer.flipX = false;
        else if (inputX < 0)
            _spriteRenderer.flipX = true;

        if (Input.GetKeyDown(KeyCode.Space) && _isGroundSansorOn)
        {
            _rb2d.velocity = new Vector2(0, _jumpForce);
            _animator.SetTrigger(Jump);
        }

        if ((inputX > 0 && _isRightWallSensorOn == false) || (inputX < 0 && _isLeftWallSensorOn == false))
            _rb2d.velocity = new Vector2(inputX * _spead, _rb2d.velocity.y);
        else
            _rb2d.velocity = new Vector2(0, _rb2d.velocity.y);

        _animator.SetFloat(SpeadX, Mathf.Abs(_rb2d.velocity.x));
        _animator.SetFloat(SpeadY, _rb2d.velocity.y);
    }

    public void GroundSensorOn()
    {
        _isGroundSansorOn = true;
        _animator.SetBool(IsGrounded, true);
    }

    public void GroundSensorOff()
    {
        _isGroundSansorOn= false;
        _animator.SetBool(IsGrounded, false);
    }

    public void RightWallSensorOn()
    {
        _isRightWallSensorOn = true;
    }

    public void RightWallSensorOff()
    {
        _isRightWallSensorOn = false;
    }

    public void LeftWallSensorOn()
    {
        _isLeftWallSensorOn = true;
    }

    public void LeftWallSensorOff()
    {
        _isLeftWallSensorOn = false;
    }
}
