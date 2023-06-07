using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInputController : MonoBehaviour
{
    public PlayerInput PlayerAction;

    //Input Event List
    public static event Action<Vector2> OnMovement;
    public static event Action OnActionButtonPressed;
    public static event Action OnSpecialButtonPressed;

    public static event Action OnActionButtonReleased;
    public static event Action OnSpecialButtonReleased;
    
    public static event Action OnRunButtonHeld;
    public static event Action OnRunButtonReleased;

    //State Manager Event List
    //public static event Action<PlayerBaseState> OnStateChanged;

    private void Update()
    {

        //Movement
        OnMovement?.Invoke(PlayerAction.actions["Movement"].ReadValue<Vector2>());

        //Action Buttons Pressed.
        if(PlayerAction.actions["Button1"].WasPressedThisFrame())
        {
            OnActionButtonPressed?.Invoke();
            return;
        }

        if(PlayerAction.actions["Button2"].WasPressedThisFrame())
        {
            OnSpecialButtonPressed?.Invoke();
            return;
        }

        //Action Buttons Held.
        if (PlayerAction.actions["RunButton"].WasPerformedThisFrame())
        {
            OnRunButtonHeld.Invoke();
        }

        if(PlayerAction.actions["RunButton"].WasReleasedThisFrame())
        {
            OnRunButtonReleased.Invoke();
        }
    }

}
