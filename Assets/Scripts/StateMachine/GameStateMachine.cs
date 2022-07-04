using System;
using System.Linq;
using CustomInputSystem;
using DG.Tweening;
using StateMachine.States;
using StateMachine.States.EnemyStates;
using UnityEngine;
using UnityEngine.Events;
namespace StateMachine
{
    public class GameStateMachine : MonoBehaviour
    {
        public UIController UIController;
        public CameraController CameraController;
        public GameData Data { get; private set; }

        private BaseGameState[] _states =
        {
            new AimState(),
            new PersonState(),
            new GameOverState()
        };

        public BaseGameState GetState(Type type)
        {
            foreach (var state in _states)
            {
                if (state.GetType() == type)
                {
                    return state;
                }
            }
            return null;
        }


        private BaseGameState _currentState;
        public void SetState(BaseGameState state)
        {
            if (state == _currentState) return;

            _currentState = state;
            _currentState.EnterState(this);
        }

        private void Awake()
        {
            

            EventSystem.OnAimButtonDown += () => SetState(GetState(typeof(AimState)));
            EventSystem.OnBulletsEnded += () => SetState(GetState(typeof(GameOverState)));
            EventSystem.OnAimButtonUp += () => SetState(GetState(typeof(PersonState)));
            EventSystem.OnEnemyEnded += () => SetState(GetState(typeof(GameOverState)));
            EventSystem.OnHealthEnded += () => SetState(GetState(typeof(GameOverState)));
            Data = Resources.Load<GameData>("Game Data");
            Data.Enemies.Clear();
        }
        private void Update()
        {
            _currentState?.UpdateState(this);
        }









    }



}
