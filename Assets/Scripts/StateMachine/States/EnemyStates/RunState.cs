using System;
using UnityEngine;
namespace StateMachine.States.EnemyStates
{
    public class RunState : BaseEnemyState
    {

        public override void EnterState(EnemyStateMachine stateMachine)
        {
            stateMachine.Animator.Play("m_pistol_run");
            stateMachine.RunPoint.parent = null;
            stateMachine.Agent.isStopped = false;
            stateMachine.Agent.destination = stateMachine.RunPoint.position;
        }
        public override void UpdateState(EnemyStateMachine stateMachine)
        {
            if (!stateMachine.Agent.pathPending)
            {
                if (stateMachine.Agent.remainingDistance <= stateMachine.Agent.stoppingDistance)
                {
                    if (!stateMachine.Agent.hasPath || stateMachine.Agent.velocity.sqrMagnitude == 0f)
                    {
                        stateMachine.SetState(stateMachine.GetState(typeof(AttackState)));

                    }
                }
            }


        }
    }
}
