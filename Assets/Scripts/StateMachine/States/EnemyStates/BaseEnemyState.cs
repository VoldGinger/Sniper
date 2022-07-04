namespace StateMachine.States
{
    public abstract class BaseEnemyState
    {
        public abstract void EnterState(EnemyStateMachine stateMachine);
        public abstract void UpdateState(EnemyStateMachine stateMachine);
    }
}
