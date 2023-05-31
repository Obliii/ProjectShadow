using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerBaseState currentState;
    public PlayerOverworldState overworldState = new PlayerOverworldState();
    public PlayerBattleState battleState = new PlayerBattleState();

    void Start()
    {
        //Sets Starting State. Starts state when state change occures.
        currentState = overworldState;
        currentState.EnterState(this);
    }

    void Update()
    {
        //Update Active State
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state) {
        //Changes state when called.
        currentState = state;
        state.EnterState(this);
    }
}