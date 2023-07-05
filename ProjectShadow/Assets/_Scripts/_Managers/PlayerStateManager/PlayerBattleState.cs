using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleState : PlayerBaseState
{
    public PlayerBattleState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
    : base (currentContext, playerStateFactory){}
    
    public override void EnterState(){
        Debug.Log("Entered Player Battle State");
    }
    
    public override void UpdateState(){
        CheckSwitchState();
    }

    public override void ExitState(){}

    public override void CheckSwitchState(){
        if(_ctx.playerInput.actions["Accept"].IsPressed()){
            SwitchState(_factory.Overworld());
        }
    }

    public override void InitializeSubState(){}
}
