using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 1f;

    [SerializeField] private PlayerInput PlayerAction;

    [SerializeField] private Vector2 movement;

    private void Update()
    {
        transform.Translate(movement);

        movement = PlayerAction.actions["Movement"].ReadValue<Vector2>() * moveSpeed * Time.deltaTime;
    }
}
