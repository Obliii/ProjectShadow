using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    const float WALKSPEED = 4f;
    const float RUNSPEED = 7f;

    public enum AnimationType
    {
        ANIM_Idle,
        ANIM_Walking,
        ANIM_Running,
    };

    Stats stats = null;
    Entity entity = null;

    [SerializeField] private SpriteRenderer spriterenderer;
    [SerializeField] private Animator controller;
    [SerializeField] private PlayerInput PlayerAction;
    
    [SerializeField] private float moveSpeed = WALKSPEED;

    [SerializeField] private Vector2 playerinput; // For the purposes of getting what buttons the player pressed for flipping the player.
    private Vector2 move;


    public AnimationType animationtype;


    private void Start()
    {
        stats = new Stats();
        entity = new Entity();
    }

    private void Update()
    {
        ManageSpeed();

        Movement();
        UpdateAnimation();

    }

    private void Movement()
    {
        playerinput = PlayerAction.actions["Movement"].ReadValue<Vector2>();

        FlipPlayer(playerinput);

        move = playerinput * moveSpeed * Time.deltaTime;
        transform.Translate(move);
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
        }

        if(flip.x <= -0.01)
        {
            spriterenderer.flipX = true;
        }
        
    }

    private void ManageSpeed()
    {
        moveSpeed = WALKSPEED;

        if(RunButtonHeld())
        {
            moveSpeed = RUNSPEED;
        }
    }

    private bool CharacterIsMoving()
    {
        if(playerinput != Vector2.zero)
        {
            return true;
        }

        return false;
    }

    private bool RunButtonHeld()
    {
        if(PlayerAction.actions["Button1"].IsInProgress())
        {
            return true;
        }

        return false;
    }


}
