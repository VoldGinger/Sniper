using System;
using System.Collections;
using System.Collections.Generic;
using CustomInputSystem;
using StateMachine;
using StateMachine.States.EnemyStates;
using UnityEngine;

public class ShootController : MonoBehaviour
{

    [SerializeField] private CameraController _cameraController;
    private int _bulletCount = 4;
    private bool _isAbleToShoot = false;
    private Coroutine _delayRoutine;
    private void Awake()
    {
        EventSystem.OnAimButtonUp += () =>
        {
            StopCoroutine(_delayRoutine);
            Shoot();
        };
        EventSystem.OnAimButtonDown += () =>
        {
           _delayRoutine = StartCoroutine(Delay());
        };
    }


    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.3f);
        _isAbleToShoot = true;

    }
    


    private void Shoot()
    {

        if (!_isAbleToShoot) return;

            _bulletCount--;
        EventSystem.InvokeEvent(EventSystem.OnShooted, _bulletCount);
        
        
        RaycastHit hit = _cameraController.CastRayFromCamera();
        if (hit.collider && (hit.collider.CompareTag("Body") || hit.collider.CompareTag("Head")))
        {
            var enemy = hit.transform.parent.GetComponent<EnemyStateMachine>();
            if (enemy) enemy.SetState(enemy.GetState(typeof(DeathState)));
        }
        CheckEnemiesIntoSphere();
        if (_bulletCount <= 0)
        {
            EventSystem.InvokeEvent(EventSystem.OnBulletsEnded);
        }
        _isAbleToShoot = false;
    }


  

    private void CheckEnemiesIntoSphere()
    {
        RaycastHit[] hits = _cameraController.CastSphereFromCamera();
        List<EnemyStateMachine> enemies = new List<EnemyStateMachine>();
        foreach (var hit in hits)
        {
            if (hit.collider)
            {
                if (hit.collider.CompareTag("Player")) continue;
              
                var enemy = hit.collider.transform.parent.GetComponent<EnemyStateMachine>();
              
                if (enemy)
                {
                    if (!(enemy.CurrentState is IdleState)) continue;
                    enemies.Add(enemy);
                }
            }
        }

        foreach (var enemy in enemies)
        {
            enemy.SetState(enemy.GetState(typeof(RunState)));
        }

    }


}





