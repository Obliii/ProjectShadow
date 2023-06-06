using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInputController : MonoBehaviour
{
    public PlayerInput PlayerAction;

    //Event List
    public static event Action<Vector2> OnMovement;
    public static event Action OnActionButton;
    public static event Action OnSpecialButton;
    public static event Action OnSpecialButton2;

    private void Update()
    {
        OnMovement?.Invoke(PlayerAction.actions["Movement"].ReadValue<Vector2>());
    }

}
