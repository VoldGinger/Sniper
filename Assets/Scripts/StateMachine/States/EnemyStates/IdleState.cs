using CustomInputSystem;
namespace StateMachine.States.EnemyStates
{
    public class IdleState : BaseEnemyState
    {
        public override void EnterState(EnemyStateMachine stateMachine)
        {
            if (stateMachine.Agent != null)
            {
                stateMachine.Agent.isStopped = true;
                stateMachine.Animator.Play("m_idle_A");
            }
           
        }
        public override void UpdateState(EnemyStateMachine stateMachine)
        {
            
        }





    }
}
