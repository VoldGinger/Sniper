namespace StateMachine.States
{
    class PersonState : BaseGameState
    {
        public override void EnterState(GameStateMachine stateMachine)
        {
            var machine = stateMachine;
            machine.CameraController.PersonMode();
            stateMachine.UIController.SetAimUIFade(0);
            stateMachine.UIController.SetStartingUIFade(1);
        }
        public override void UpdateState(GameStateMachine stateMachine)
        {
            
        }
    }
}
