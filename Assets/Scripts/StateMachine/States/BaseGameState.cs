namespace StateMachine.States
{
    public abstract class BaseGameState
    {
        public abstract void EnterState(GameStateMachine stateMachine);
        public abstract void UpdateState(GameStateMachine stateMachine);
    }


}
