using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public enum AnimationType
{
    ANIM_Idle,
    ANIM_Walking,
    ANIM_Running,
};

public class PlayerMovement : MonoBehaviour
{
    public AnimationType animationtype;

    const float WALKSPEED = 4f;
    const float RUNSPEED = 7f;

    private float MoveSpeed = WALKSPEED;

    Stats stats = null;
    Entity entity = null;

    public SpriteRenderer spriterenderer;
    public Animator controller;

    private void OnEnable()
    {
        KeyboardInputController.OnMovement += OnMovement;

        //PlayerStateManager.OnStateChange += StateUpdate;
        //PlayerStateManager.OnStateChange += OnStateChange;
    }

    private void OnDisable()
    {
        KeyboardInputController.OnMovement -= OnMovement;

        //PlayerStateManager.OnStateChange -= StateUpdate;
        //PlayerStateManager.OnStateChange -= OnStateChange;
    }

    //This could be converted to StateUpdate once we get to that stage.
    private void Update()
    {
        //Only if we're on the overworld state.
        //if (PlayerStateManager.GetCurrentState != )
        //    return;

        UpdateSpeed();
        UpdateAnimation();
    }
    private void OnStateChange(PlayerBaseState state)
    {

    }

    private void OnMovement(Vector2 move)
    {
        FlipPlayer(move);

        Vector2 movement = move * MoveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
    
    private void UpdateAnimation()
    {
        if(!CharacterIsMoving())
        {
            animationtype = AnimationType.ANIM_Idle;
        }
        else if(CharacterIsMoving() && RunButtonHeld())
        {
            animationtype = AnimationType.ANIM_Running;
        }

        else
        {
            animationtype = AnimationType.ANIM_Walking;
        }

        //RUNNING TO BE ADDED.

        int animationNum = (int)animationtype;
        controller.SetInteger("PlayerState", animationNum);
    }

    

    private void FlipPlayer(Vector2 flip)
    {
        if(flip.x >= 0.01)
        {
            spriterenderer.flipX = false;
            return;
        }

        spriterenderer.flipX = true;        
    }

    private void UpdateSpeed()
    {
        MoveSpeed = WALKSPEED;

        if(RunButtonHeld())
        {
            MoveSpeed = RUNSPEED;
        }
    }
}
