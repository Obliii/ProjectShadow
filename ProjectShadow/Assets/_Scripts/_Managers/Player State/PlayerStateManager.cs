using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerBaseState currentState;
    public PlayerOverworldState overworldState = new PlayerOverworldState();
    public PlayerBattleState battleState = new PlayerBattleState();

    //private void OnEnable()
    //{
    //    EventManager.ChangeOverworldState += ChangeOverworldState;
    //    EventManager.ChangeBattleState += ChangeBattleState;
    //}

    //private void OnDisable()
    //{
    //    EventManager.ChangeOverworldState -= ChangeOverworldState;
    //    EventManager.ChangeBattleState -= ChangeBattleState;
    //}

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

    //public void ChangeBattleState()
    //{
    //    currentState = battleState;
    //    currentState.EnterState(this);
    //}

    //public void ChangeOverworldState()
    //{
    //    currentState = overworldState;
    //    currentState.EnterState(this);
    //}
}