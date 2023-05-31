using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public enum AnimationType
    {
        ANIM_Idle,
        ANIM_Walking,
        ANIM_Running,
    };

    [SerializeField] private SpriteRenderer spriterenderer;
    [SerializeField] private Animator controller;
    [SerializeField] private PlayerInput PlayerAction;
    
    [SerializeField] private float moveSpeed = 1f;

    [SerializeField] private Vector2 playerinput; // For the purposes of getting what buttons the player pressed for flipping the player.
    private Vector2 move;


    public AnimationType animationtype;


    private void Update()
    {
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
        if(playerinput == Vector2.zero)
        {
            animationtype = AnimationType.ANIM_Idle;
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
        Debug.Log(flip.x);

        if(flip.x >= 0.01)
        {
            spriterenderer.flipX = false;
        }

        if(flip.x <= -0.01)
        {
            spriterenderer.flipX = true;
        }
        
    }


}
