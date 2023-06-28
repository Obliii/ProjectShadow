using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    //State Variables
    PlayerBaseState _currentState;
    PlayerStateFactory _states;

    public PlayerInput _playerInput;
    public SpriteRenderer _spriteRenderer;
    public BoxCollider2D _playerCollider;
    public Animator _playerAnimator;

    bool _isRunPressed;

    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; }}
    public bool isRunPressed { get { return _isRunPressed; }}
    public PlayerInput playerInput { get { return _playerInput; }}
    public SpriteRenderer spriteRenderer { get { return _spriteRenderer; }}
    public BoxCollider2D playerCollider { get { return _playerCollider; }}
    public Animator playerAnimator { get { return _playerAnimator; }}

    void Awake()
    {
        _states = new PlayerStateFactory(this);
        _playerCollider = GetComponent<BoxCollider2D>();
        _currentState = _states.Overworld();
        _currentState.EnterState();
    }

    void Update()
    {
        _currentState.UpdateStates();
        _isRunPressed = _playerInput.actions["Run"].IsPressed();
    }
}