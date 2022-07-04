using CustomInputSystem;
using DG.Tweening;
using UnityEngine;
namespace StateMachine.States
{
    class AimState : BaseGameState
    {
        public override void EnterState(GameStateMachine stateMachine)
        {
            stateMachine.CameraController.AimMode();
            InputSystem.StartDeltaPos = InputSystem.GetTouchPosition();
            stateMachine.UIController.SetAimUIFade(1);
        }

        public override void UpdateState(GameStateMachine stateMachine)
        {
            stateMachine.CameraController.Delta =
                (InputSystem.StartDeltaPos
                    - InputSystem.GetTouchPosition())
                * Time.fixedDeltaTime
                * stateMachine.Data.RotationFactor;


        }
    }
}
