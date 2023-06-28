public class PlayerStateFactory
{
    PlayerStateManager _context;

    public PlayerStateFactory(PlayerStateManager currentContext){
        _context = currentContext;
    }

    public PlayerBaseState Overworld(){
        return new PlayerOverworldState(_context, this);
    }
    public PlayerBaseState Battle(){
        return new PlayerBattleState(_context, this);
    }
    public PlayerBaseState Running(){
        return new PlayerRunningState(_context, this);
    }
    public PlayerBaseState Walking(){
        return new PlayerWalkingState(_context, this);
    }
}
