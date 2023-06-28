using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOverworldState : PlayerBaseState
{
    const float _walkSpeed = 4f;
    const float _runSpeed = 7f;
    private float _moveSpeed;
    

    public PlayerOverworldState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory)
    : base (currentContext, playerStateFactory){}
    
    public override void EnterState(){
        Debug.Log("Entered Player Overworld State");
    }
    
    public override void UpdateState(){
        CheckSwitchState();
        OnMovement();
    }

    public override void ExitState(){}

    public override void CheckSwitchState(){
        if(_ctx.playerInput.actions["Cancel"].IsPressed()){
            SwitchState(_factory.Battle());
        }
    }

    public override void InitializeSubState(){}

    private void OnMovement()
    {
        Vector2 move = _ctx.playerInput.actions["Movement"].ReadValue<Vector2>();
        bool running = _ctx.playerInput.actions["Run"].IsPressed();
        FlipPlayer(move);

        Vector2 movement = move.normalized * _moveSpeed * Time.deltaTime;
        _ctx.GetComponent<BoxCollider2D>().transform.Translate(movement);

        if (_ctx.isRunPressed){
            Debug.Log("Run Pressed");
            _ctx.playerAnimator.Play("Player-Walking");
            _moveSpeed = _runSpeed;
        }
        else{
            _ctx.playerAnimator.Play("Player-Idle");
            _moveSpeed = _walkSpeed;
        }
    }

    private void FlipPlayer(Vector2 flip)
    {
        if(flip.x >= 0.01)
        {
            _ctx.spriteRenderer.flipX = false;
            return;
        }

        if(flip.x <= -0.01)
        {
            _ctx.spriteRenderer.flipX = true;
            return;
        }
    }
}
