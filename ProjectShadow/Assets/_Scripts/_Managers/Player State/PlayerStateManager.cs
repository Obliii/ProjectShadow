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

    /// <summary>
    ///  Could also have this run with events,
    ///  The UpdateState function could launch an event
    ///  that would tell all others scripts that rely on it to update.
    ///  Could use a "OnStateUpdate" in my own scripts that wait for it.
    ///  Instead of having to goto this script and check to see what state we're on.
    /// </summary>

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

    public PlayerBaseState GetCurrentState() {
        return currentState;
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