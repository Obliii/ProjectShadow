using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerBaseState
{
    public static PlayerInput playerAction;

    public abstract void EnterState(PlayerStateManager player);

    public abstract void UpdateState(PlayerStateManager player);
}