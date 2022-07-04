using CustomInputSystem;
namespace StateMachine.States.EnemyStates
{
    public class DeathState : BaseEnemyState
    {

        public override void EnterState(EnemyStateMachine stateMachine)
        {
            stateMachine.Data.Enemies.Remove(stateMachine);
            CheckEnemiesAmount(stateMachine);
            
            stateMachine.Agent.isStopped = true;
            stateMachine.Animator.Play("m_death_A");
            stateMachine.enabled = false;
        }
        public override void UpdateState(EnemyStateMachine stateMachine)
        {
           
        }
        
        
        private void CheckEnemiesAmount(EnemyStateMachine stateMachine)
        {
            if (stateMachine.Data.Enemies.Count == 0)
            {
                EventSystem.InvokeEvent(EventSystem.OnEnemyEnded);
            }


        }
        
    }
}
