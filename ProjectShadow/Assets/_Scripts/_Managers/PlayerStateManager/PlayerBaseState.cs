public abstract class PlayerBaseState
{
    protected PlayerStateManager _ctx;
    protected PlayerStateFactory _factory;
    protected PlayerBaseState _currentSubState;
    protected PlayerBaseState _currentSuperState;

    public PlayerBaseState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory){
        _ctx = currentContext;
        _factory = playerStateFactory;
    }

    public abstract void EnterState();
    
    public abstract void UpdateState();

    public abstract void ExitState();

    public abstract void CheckSwitchState();

    public abstract void InitializeSubState(); 

    public void UpdateStates(){
        UpdateState();
        if (_currentSubState != null){
            _currentSubState.UpdateState();
        }
    }

    protected void SwitchState(PlayerBaseState newState){
        ExitState();
        newState.EnterState();
        _ctx.CurrentState = newState;
    }

    protected void SetSuperState(PlayerBaseState newSuperState){
        _currentSuperState = newSuperState;
    }

    protected void SetSubState(PlayerBaseState newSubState){
        _currentSubState = newSubState;
        newSubState.SetSuperState(this);
    }
}