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
    public PlayerInput PlayerAction;

    public AnimationType animationtype;

    const float WALKSPEED = 4f;
    const float RUNSPEED = 7f;

    private float MoveSpeed = WALKSPEED;

    Entity entity = null;

    public SpriteRenderer spriterenderer;
    public Animator controller;

    private bool PlayerRunning;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        KeyboardInputController.OnRunButtonHeld += OnRunButtonHeld;
        KeyboardInputController.OnRunButtonReleased += OnRunButtonReleased;

    }

    private void OnDisable()
    {

    }

    //This could be converted to StateUpdate once we get to that stage.
    private void Update()
    {

        //Only if we're on the overworld state.
        //if (PlayerStateManager.GetCurrentState != )
        //    return;

        
        UpdateSpeed();
        UpdateAnimation();
        OnMovement();
    }

    private void OnMovement()
    {
        Vector2 move = PlayerAction.actions["Movement"].ReadValue<Vector2>();
        FlipPlayer(move);

        Vector2 movement = move.normalized * MoveSpeed * Time.deltaTime;
        transform.Translate(movement);

        if(move.x != 0 || move.y != 0)
        {
            UpdateAnimation(true);
        }
    }

    private void UpdateAnimation(bool CharacterIsMoving = false)
    {
        if (!CharacterIsMoving)
        {
            animationtype = AnimationType.ANIM_Idle;
        }
        else if (CharacterIsMoving && PlayerRunning)
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

        if(flip.x <= -0.01)
        {
            spriterenderer.flipX = true;
            return;
        }
    }

    private void UpdateSpeed()
    {
        MoveSpeed = WALKSPEED;

        if(PlayerRunning)
        {
            MoveSpeed = RUNSPEED;
        }
    }

    private void OnRunButtonHeld()
    {
        PlayerRunning = true;
    }

    private void OnRunButtonReleased()
    {
        PlayerRunning = false;
    }

    private void OnStateChange(PlayerBaseState state)
    {

    }
}
