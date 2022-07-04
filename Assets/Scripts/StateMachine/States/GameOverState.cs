using System.Linq;
using CustomInputSystem;
using StateMachine.States;
using StateMachine.States.EnemyStates;
namespace StateMachine
{
    internal class GameOverState : BaseGameState
    {

        public override void EnterState(GameStateMachine stateMachine)
        {
            EventSystem.OnAimButtonDown = null;
            EventSystem.OnAimButtonUp = null;
            EventSystem.InvokeEvent(stateMachine.Data.Enemies.Count == 0 ? EventSystem.Win : EventSystem.Lose);
            EventSystem.MakeAllEventsNull();
        }
        public override void UpdateState(GameStateMachine stateMachine)
        {

        }
    }
}
