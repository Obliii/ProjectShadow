using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class EventManager : MonoBehaviour
{
    public PlayerInput PlayerAction;

    //public static event Action ChangeBattleState;
    //public static event Action ChangeOverworldState;

    public static event Action OnMovement;

    void Update()
    {

        //if (PlayerAction.actions["Button1"].WasPressedThisFrame())
        //{
        //    ChangeBattleState?.Invoke();
        //    Debug.Log("Ping!");
        //}

        //if (PlayerAction.actions["Button2"].WasPressedThisFrame())
        //{
        //    ChangeOverworldState?.Invoke();
        //    Debug.Log("Pong!");
        //}
    }
}
