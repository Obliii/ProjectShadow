using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBattleState : PlayerBaseState

{
    //Triggers on entering current state.
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Player Start Battle State");
    }

    //Update
    public override void UpdateState(PlayerStateManager player) 
    {
        //Trigger and function to change state.
        //if(playerAction.actions["Button1"].IsPressed())
        //{
        //    player.SwitchState(player.overworldState);
        //}
    }
}