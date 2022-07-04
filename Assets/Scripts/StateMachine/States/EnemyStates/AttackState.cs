using UnityEngine;
namespace StateMachine.States.EnemyStates
{
    public class AttackState : BaseEnemyState
    {
        
        public override void EnterState(EnemyStateMachine stateMachine)
        {
            stateMachine.Animator.Play("m_pistol_shoot");
        }
        public override void UpdateState(EnemyStateMachine stateMachine)
        {
            LookAtPlayer(stateMachine);

        }
        
        private static void LookAtPlayer(EnemyStateMachine stateMachine)
        {
            var targetVector = stateMachine.transform.position - stateMachine.PlayerTransform.position;
            targetVector.y = 0;
            stateMachine.transform.forward =
                Vector3.Lerp(stateMachine.transform.forward, -targetVector, Time.deltaTime);
        }
    }
}
