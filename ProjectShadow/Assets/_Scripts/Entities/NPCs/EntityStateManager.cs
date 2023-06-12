using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// What the AI will primarily do.
public enum AIMODE
{
    None,
    AIMODE_Stationary,
    AIMODE_Patrol,
    AIMODE_PursuePlayer,
    AIMODE_FollowBehindPlayer,
}

public enum EntityAnimation
{
    None,
    EntityAnimation_Idle,
    EntityAnimation_Moving,
    EntityAnimation_Attack,
}

public class EntityStateManager : MonoBehaviour
{
    //Basic Necessities.
    private Vector2 SpawnPoint;

    public Entity entity;

    //Entity States
    public BaseEntityState CurrentState;
    public BaseEntityStationaryState StationaryState = new BaseEntityStationaryState();
    public BaseEntityChaseState ChaseState = new BaseEntityChaseState();
    //public BaseEntityFollowState needed

    //Options for the Entity
    public AIMODE AIMode;
    public bool IsSpecial;
    public bool CanSeePlayer;
    public Vector2[] Waypoints;
    public float ChaseRange = 50f;

    private void OnEnable()
    {
        //Waits for StateMachine Changes
    }

    private void OnDisable()
    {
        //Waits for StateMachine Changes
    }

    private void Start()
    {
        SpawnPoint = transform.position;
        CurrentState = StationaryState;
    }
    private void Update()
    {
        CurrentState.UpdateState();
    }

    void DetectPlayer()
    {

    }



}
