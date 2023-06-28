using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingState : PlayerBaseState
{
    public PlayerWalkingState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
    : base (currentContext, playerStateFactory){}
    
    public override void EnterState(){
        Debug.Log("Entered Player Walking State");
    }
    
    public override void UpdateState(){
        CheckSwitchState();
    }

    public override void ExitState(){}

    public override void CheckSwitchState(){
        
    }

    public override void InitializeSubState(){}
}
