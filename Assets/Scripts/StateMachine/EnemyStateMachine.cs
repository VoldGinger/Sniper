using System;
using System.Collections.Generic;
using CustomInputSystem;
using Health;
using StateMachine.States;
using StateMachine.States.EnemyStates;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
namespace StateMachine
{
    public class EnemyStateMachine : MonoBehaviour
    {
        public Transform RunPoint;

        private readonly BaseEnemyState[] _enemyStates =
        {
            new AttackState(),
            new RunState(),
            new IdleState(),
            new DeathState()
        };
        public BaseEnemyState GetState(Type type)
        {
            foreach (var s in _enemyStates)
            {
                if (s.GetType() == type) return s;
            }
            return null;
        }

        [HideInInspector]
        public NavMeshAgent Agent;
        [HideInInspector]
        public Animator Animator;
        public GameData Data { get; private set; }
        private ParticleSystem _particle;
        public Transform PlayerTransform { get; private set; }

        public BaseEnemyState CurrentState { get; private set; }

        public void SetState(BaseEnemyState state)
        {
            CurrentState = state;
            CurrentState.EnterState(this);
        }

        private void Awake()
        {
            _particle = GetComponentInChildren<ParticleSystem>();
            PlayerTransform = FindObjectOfType<PlayerHealth>().transform;
            Agent = GetComponent<NavMeshAgent>();
            Animator = GetComponent<Animator>();
            SubscribeOnEndEvents();
            
            
            Data = Resources.Load<GameData>("Game Data");
        }
        private void Start()
        {
            Data.Enemies.Add(this);
            SetState(GetState(typeof(IdleState)));
        }

        private void Update()
        {
            CurrentState?.UpdateState(this);
        }


        public void DestroyEnemy()
        {
            Destroy(gameObject);
        }


        public void PlayShootParticles()
        {
            _particle.Play();
        }


        public void TryDamagePlayer()
        {
            Vector3 randomPoint = PlayerTransform.position + Random.insideUnitSphere * 0.7f;
            Vector3 randomDir = randomPoint - transform.position;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, randomDir, out hit, 200, LayerMask.GetMask("Player")))
            {
                hit.collider.GetComponent<Damageable>().MakeDamage(1);
            }

        }




        private void SubscribeOnEndEvents()
        {
            EventSystem.OnBulletsEnded += () => SetState(GetState(typeof(IdleState)));
            EventSystem.OnHealthEnded += () => SetState(GetState(typeof(IdleState)));
           
        }
        
        

    }

}
