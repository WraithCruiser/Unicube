using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    //PlayerContoller Components
    [SerializeField] private Rigidbody2D _playerRigidBody2D;
    //Player Meta
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _pushForce;
    [SerializeField] private int _additionalJumpCount;
    public Vector3 _spawnPoint = new Vector3(-4.46f, -3.5f, 0);
    //Player Control Hotkeys
    [SerializeField] private KeyCode _jumpKey;
    [SerializeField] private KeyCode _leftPushKey;
    [SerializeField] private KeyCode _rightPushKey;
    [SerializeField] private KeyCode _downPushKey;
    //Player Physics Fields
    [SerializeField] private ContactFilter2D _contactFilter2D;
    private readonly RaycastHit2D[] _results = new RaycastHit2D[1];
    private bool _isGrounded;


    private void Awake()
    {
        _playerRigidBody2D.sleepMode = RigidbodySleepMode2D.NeverSleep; 
    }

    private void FixedUpdate()
    {
        //Checks if grounded
        int collisionCount = _playerRigidBody2D.Cast(Vector2.down, _contactFilter2D, _results, 0.2f);
        if (collisionCount >= 1)
        {
            _isGrounded = true;
            _additionalJumpCount = 1;
        }
        else
        {
            _isGrounded = false;
        }
    }

    public void Kill()
    {
        transform.position = _spawnPoint;
    }

    public void SaveSpawnPoint()
    {
        _spawnPoint = transform.position;
    }

    private void Update()
    {
        //If grounded sliding on ground
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
        // If not grounded spinning in air 
        if (!_isGrounded)
        {
            if (Input.GetKeyDown(_jumpKey))
            {
                Jump();
            }
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
        //Checks additional jumps in air and decrement it if > 0 and called function Jump();
        if (_additionalJumpCount > 0)
        {
            _playerRigidBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _additionalJumpCount--;
        }
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
