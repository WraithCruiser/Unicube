using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player Layers
    [SerializeField] private LayerMask _groundLayerMask;
    //PlayerContoller Components
    [SerializeField] private Rigidbody2D _playerRigidBody2D;
    //Player Meta
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _pushForce;
    //Player Control Hotkeys
    [SerializeField] private KeyCode _jumpKey;
    [SerializeField] private KeyCode _leftPushKey;
    [SerializeField] private KeyCode _rightPushKey;
    [SerializeField] private KeyCode _downPushKey;
    //Player Physics Variables
    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];
    private bool _isGrounded; 


    private void Awake()
    {
        _playerRigidBody2D.sleepMode = RigidbodySleepMode2D.NeverSleep; 
    }

    private void FixedUpdate()
    {
        int collisionCount = _playerRigidBody2D.Cast(Vector2.down, _results, 0.2f);
        if (collisionCount >= 1)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    private void Update()
    {
        if (_isGrounded)
        {
            if (Input.GetKeyDown(_jumpKey))
            {
                Jump();
            }
            if (Input.GetKeyDown(_leftPushKey))
            {
                PushLeft();
            }
            if (Input.GetKeyDown(_rightPushKey))
            {
                PushRight();
            }
            if (Input.GetKeyDown(_downPushKey))
            {
                PushDown();
            }
        }

        if (!_isGrounded)
        {
            if (Input.GetKey(_leftPushKey))
            {
                SpinLeft();
            }
            if (Input.GetKey(_rightPushKey))
            {
                SpinRight();
            }
        }
    }
    //Movement Functions
    private void Jump()
    {
        _playerRigidBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void PushLeft()
    {
        _playerRigidBody2D.AddForce(Vector2.left * _pushForce, ForceMode2D.Impulse);
    }
    private void PushRight()
    {
        _playerRigidBody2D.AddForce(Vector2.right * _pushForce, ForceMode2D.Impulse);
    }
    private void PushDown()
    {
        _playerRigidBody2D.AddForce(Vector2.down * _pushForce, ForceMode2D.Impulse);
    }

    private void SpinLeft()
    {
        _playerRigidBody2D.AddTorque(0.25f);
        _playerRigidBody2D.AddForce(Vector2.left * _pushForce * Time.deltaTime, ForceMode2D.Impulse);
    }
    private void SpinRight()
    {
        _playerRigidBody2D.AddTorque(-0.25f);
        _playerRigidBody2D.AddForce(Vector2.right * _pushForce * Time.deltaTime, ForceMode2D.Impulse);
    }
}
