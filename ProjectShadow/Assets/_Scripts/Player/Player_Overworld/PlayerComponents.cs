using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerComponents
{
    public enum AnimationType
    {
        ANIM_Idle,
        ANIM_Walking,
        ANIM_Running,
    };

    Stats stats = null;
    Entity entity = null;



    [SerializeField] public SpriteRenderer spriterenderer;
    [SerializeField] public Animator controller;


    public AnimationType animationtype;
}